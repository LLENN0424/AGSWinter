using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject missilePrefab; // �~�T�C���̃v���n�u
    public Transform target; // �v���C���[��Transform
    public float rotationSpeed = 5f; // ��]���x�i�K�؂Ȓl�ɏ������j

    public float detectionRange = 10f; // �v���C���[�����o����͈�
    public float missileSpeed = 10f; // �~�T�C���̑��x
    public float shootInterval = 2f; // �~�T�C���𔭎˂���Ԋu�i�b�j

    private float lastShootTime; // �O��~�T�C���𔭎˂�������

    void Update()
    {
        // �v���C���[�����͈͓��ɂ��邩�`�F�b�N
        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            // �G�̈ʒu���v���C���[�̈ʒu�Ɍ�����iY���̂݉�]�j
            Vector3 directionToPlayer = target.position - transform.position;
            directionToPlayer.y = 0f; // Y�������̉�]�𖳌��ɂ���i���������݂̂������j
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // �~�T�C���𔭎˂���Ԋu���`�F�b�N
            if (Time.time - lastShootTime >= shootInterval)
            {
                // �v���C���[�̕����Ɍ������ă~�T�C���𔭎�
                LaunchMissile();
                lastShootTime = Time.time; // �~�T�C���𔭎˂������Ԃ��L�^
            }
        }
    }

    void LaunchMissile()
    {
        // �~�T�C�����v���n�u���琶��
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        // �v���C���[�̕���������
        missile.transform.LookAt(target);
        // �~�T�C���ɑ��x��^���Ĕ���
        missile.GetComponent<Rigidbody>().velocity = missile.transform.forward * missileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Missile"))
        {
            // �~�T�C����j������
            Destroy(gameObject);
            // �Փ˂����I�u�W�F�N�g���v���C���[�ł���ꍇ�A�v���C���[�Ƀ_���[�W��^����
            // collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

        }
    }
}
