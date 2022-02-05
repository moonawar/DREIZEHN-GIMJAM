using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject wave;
    public BossAttack bossAttack;

    void Awake()
    {
        gameOver.SetActive(false);
    }

    public void GameOver(){
        gameOver.SetActive(true);
        
        if (wave != null)
        {
            wave.GetComponent<WaveSpawner>().enabled = false;
        }
        if (bossAttack != null) {
            bossAttack.enabled = false;
        }
    }

}
