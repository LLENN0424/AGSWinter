using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public int damageAmount = 10; // ミサイルのダメージ量

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            // ミサイルを破棄する
            Destroy(gameObject);
            // 衝突したオブジェクトがプレイヤーである場合、プレイヤーにダメージを与える
            // collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

        }
       
    }


}
