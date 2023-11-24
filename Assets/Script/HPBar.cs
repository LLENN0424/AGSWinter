using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider; // Unity��Slider UI�v�f���֘A�t����

    // �v���C���[�̍ő�̗�
    public int maxHealth = 100;

    // ���݂̗̑́i�����l�͍ő�̗͂Ɠ����j
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // �������F���݂̗̑͂��ő�̗͂ɐݒ�
        currentHealth = maxHealth;

        //�X���C�_�[�̍ő�l��ݒ�
        slider.maxValue = maxHealth;
        // �X���C�_�[�̌��ݒl��ݒ�
        slider.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // HP��0�ȉ��ɂȂ����ꍇ�̏����i�Ⴆ�΃v���C���[�̎��S�����j
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // �v���C���[�����S�����ۂ̏��������s�i��: �Q�[���I�[�o�[��ʂ̕\���Ȃǁj
        // �����Ɏ��S���̏�����ǉ�
    }
}
