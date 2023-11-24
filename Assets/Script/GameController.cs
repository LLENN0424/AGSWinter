using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies; // �G�̔z��

    void Update()
    {
        // �G�̐���0�Ȃ�΃Q�[���N���A
        if (AllEnemiesDefeated())
        {
            // �Q�[���N���A�V�[���ɑJ�ڂ���
            SceneManager.LoadScene("GameClearScene");
        }
    }

    bool AllEnemiesDefeated()
    {
        // �G�̐��𐔂���
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // �S�Ă̓G�����Ȃ���� true ��Ԃ�
        return enemies.Length == 0;
    }
}
