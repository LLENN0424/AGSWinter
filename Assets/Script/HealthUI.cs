using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth playerHealth; // プレイヤーの体力を管理するスクリプトを関連付ける

    void Update()
    {
        // healthTextにプレイヤーの体力を表示
        healthText.text = "HP: " + playerHealth.currentHealth.ToString();
    }
}
