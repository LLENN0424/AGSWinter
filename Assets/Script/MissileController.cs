using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public int damageAmount = 10; // �~�T�C���̃_���[�W��

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            // �~�T�C����j������
            Destroy(gameObject);
            // �Փ˂����I�u�W�F�N�g���v���C���[�ł���ꍇ�A�v���C���[�Ƀ_���[�W��^����
            // collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

        }
       
    }


}
