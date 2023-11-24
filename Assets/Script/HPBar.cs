using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider; // UnityのSlider UI要素を関連付ける

    // プレイヤーの最大体力
    public int maxHealth = 100;

    // 現在の体力（初期値は最大体力と同じ）
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化：現在の体力を最大体力に設定
        currentHealth = maxHealth;

        //スライダーの最大値を設定
        slider.maxValue = maxHealth;
        // スライダーの現在値を設定
        slider.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // HPが0以下になった場合の処理（例えばプレイヤーの死亡処理）
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // プレイヤーが死亡した際の処理を実行（例: ゲームオーバー画面の表示など）
        // ここに死亡時の処理を追加
    }
}
