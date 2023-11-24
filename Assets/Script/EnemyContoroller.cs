using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject missilePrefab; // ミサイルのプレハブ
    public Transform target; // プレイヤーのTransform
    public float rotationSpeed = 5f; // 回転速度（適切な値に初期化）

    public float detectionRange = 10f; // プレイヤーを検出する範囲
    public float missileSpeed = 10f; // ミサイルの速度
    public float shootInterval = 2f; // ミサイルを発射する間隔（秒）

    private float lastShootTime; // 前回ミサイルを発射した時間

    void Update()
    {
        // プレイヤーが一定範囲内にいるかチェック
        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            // 敵の位置をプレイヤーの位置に向ける（Y軸のみ回転）
            Vector3 directionToPlayer = target.position - transform.position;
            directionToPlayer.y = 0f; // Y軸方向の回転を無効にする（水平方向のみを向く）
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // ミサイルを発射する間隔をチェック
            if (Time.time - lastShootTime >= shootInterval)
            {
                // プレイヤーの方向に向かってミサイルを発射
                LaunchMissile();
                lastShootTime = Time.time; // ミサイルを発射した時間を記録
            }
        }
    }

    void LaunchMissile()
    {
        // ミサイルをプレハブから生成
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        // プレイヤーの方向を向く
        missile.transform.LookAt(target);
        // ミサイルに速度を与えて発射
        missile.GetComponent<Rigidbody>().velocity = missile.transform.forward * missileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Missile"))
        {
            // ミサイルを破棄する
            Destroy(gameObject);
            // 衝突したオブジェクトがプレイヤーである場合、プレイヤーにダメージを与える
            // collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

        }
    }
}
