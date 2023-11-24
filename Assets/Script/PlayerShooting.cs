using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    private FPS testInputAction_;

    public GameObject bulletPrefab; // �e�̃v���n�u
    public float bulletSpeed = 10f; // �e�̈ړ����x
    public Transform target; //�G
    public float rotationSpeed = 5f; // ��]���x�i�K�؂Ȓl�ɏ������j

    public Text ammoText;
    public int maxAmmo = 6;  // �����̒e��
    private int currentAmmo;  // ���݂̎c�e��

    void Start()
    {
        testInputAction_= new FPS();
        testInputAction_.Enable();

        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {


        // �}�E�X�̍��N���b�N�����o
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            // �v���C���[�̈ʒu���擾
            Vector3 playerPosition = transform.position;

            // �v���C���[�̐��ʂɌ������Ēe�𔭎�
            Vector3 shootDirection = transform.forward;

            // �e�𐶐����Ĕ���
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // �e�ɑ��x��^���Ĕ���
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
            currentAmmo--;
            UpdateAmmoUI();
        }
        else if (currentAmmo < maxAmmo && currentAmmo > 0)
        {
            // �����[�h
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
        // UI�Ɏc�e���𔽉f
       ammoText.text = "�e��: " + currentAmmo.ToString();
    }
}
