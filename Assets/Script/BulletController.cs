using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public int damageAmount = 10; // のダメージ量

    

    // 弾が何かに衝突した時の処理（例えば敵に当たったらダメージを与えるなど）は、必要に応じてここに追加できます

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            // 弾を破棄する
            Destroy(gameObject);
        }
        // 衝突したオブジェクトがプレイヤーである場合、プレイヤーにダメージを与える
        //collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }


}
