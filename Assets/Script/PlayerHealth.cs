using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // プレイヤーの最大体力
    public int currentHealth; // 現在の体力

    // Start is called before the first frame update
    void Start()
    {
        // ゲーム開始時に現在の体力を最大体力に設定
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        // ダメージを受けた際に体力を減らす処理
        // 体力が0以下になった場合の処理を追加することが一般的
        currentHealth -= damage; 
    }

}
