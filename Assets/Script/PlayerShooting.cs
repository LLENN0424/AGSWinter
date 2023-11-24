using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    private FPS testInputAction_;

    public GameObject bulletPrefab; // 弾のプレハブ
    public float bulletSpeed = 10f; // 弾の移動速度
    public Transform target; //敵
    public float rotationSpeed = 5f; // 回転速度（適切な値に初期化）

    public Text ammoText;
    public int maxAmmo = 6;  // 初期の弾数
    private int currentAmmo;  // 現在の残弾数

    void Start()
    {
        testInputAction_= new FPS();
        testInputAction_.Enable();

        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {


        // マウスの左クリックを検出
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            // プレイヤーの位置を取得
            Vector3 playerPosition = transform.position;

            // プレイヤーの正面に向かって弾を発射
            Vector3 shootDirection = transform.forward;

            // 弾を生成して発射
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // 弾に速度を与えて発射
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
            currentAmmo--;
            UpdateAmmoUI();
        }
        else if (currentAmmo < maxAmmo && currentAmmo > 0)
        {
            // リロード
            if (testInputAction_.Player.Reload.triggered)
            {
                currentAmmo = maxAmmo;
                UpdateAmmoUI();
            }
        }
        else
        {
            if (testInputAction_.Player.Fire.triggered)
            {
                currentAmmo = maxAmmo;
                UpdateAmmoUI();
            }
        }
    }

    void UpdateAmmoUI()
    {
        // UIに残弾数を反映
       ammoText.text = "弾数: " + currentAmmo.ToString();
    }
}
