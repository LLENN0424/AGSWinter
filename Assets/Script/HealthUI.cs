using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth playerHealth; // �v���C���[�̗̑͂��Ǘ�����X�N���v�g���֘A�t����

    void Update()
    {
        // healthText�Ƀv���C���[�̗̑͂�\��
        healthText.text = "HP: " + playerHealth.currentHealth.ToString();
    }
}
