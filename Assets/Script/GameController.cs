using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies; // “G‚Ì”z—ñ

    void Update()
    {
        // “G‚Ì”‚ª0‚È‚ç‚ÎƒQ[ƒ€ƒNƒŠƒA
        if (AllEnemiesDefeated())
        {
            // ƒQ[ƒ€ƒNƒŠƒAƒV[ƒ“‚É‘JˆÚ‚·‚é
            SceneManager.LoadScene("GameClearScene");
        }
    }

    bool AllEnemiesDefeated()
    {
        // “G‚Ì”‚ğ”‚¦‚é
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // ‘S‚Ä‚Ì“G‚ª‚¢‚È‚¯‚ê‚Î true ‚ğ•Ô‚·
        return enemies.Length == 0;
    }
}
