using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �v���C���[�̍ő�̗�
    public int currentHealth; // ���݂̗̑�

    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���J�n���Ɍ��݂̗̑͂��ő�̗͂ɐݒ�
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        // �_���[�W���󂯂��ۂɑ̗͂����炷����
        // �̗͂�0�ȉ��ɂȂ����ꍇ�̏�����ǉ����邱�Ƃ���ʓI
        currentHealth -= damage; 
    }

}
