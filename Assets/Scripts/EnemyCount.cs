using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    public Text enemyCountText;
    int enemyCount;
    public GameObject canvasObject;

    void Update()
    {
        canvasObject.SetActive(false);
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCountText.text = "Enemy Count = " + enemyCount;
        if (enemyCount <= 0)
        {
            canvasObject.SetActive(true);
        }
    }
}
