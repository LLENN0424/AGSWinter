using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public int damageAmount = 10; // �̃_���[�W��

    

    // �e�������ɏՓ˂������̏����i�Ⴆ�ΓG�ɓ���������_���[�W��^����Ȃǁj�́A�K�v�ɉ����Ă����ɒǉ��ł��܂�

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            // �e��j������
            Destroy(gameObject);
        }
        // �Փ˂����I�u�W�F�N�g���v���C���[�ł���ꍇ�A�v���C���[�Ƀ_���[�W��^����
        //collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }


}
