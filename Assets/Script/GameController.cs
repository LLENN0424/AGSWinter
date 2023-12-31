using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies; // 敵の配列

    void Update()
    {
        // 敵の数が0ならばゲームクリア
        if (AllEnemiesDefeated())
        {
            // ゲームクリアシーンに遷移する
            SceneManager.LoadScene("GameClearScene");
        }
    }

    bool AllEnemiesDefeated()
    {
        // 敵の数を数える
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 全ての敵がいなければ true を返す
        return enemies.Length == 0;
    }
}
