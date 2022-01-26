using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemyCountText;
    int enemyCount;

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCountText.text = "Enemy Count = " + enemyCount;
    }
}
