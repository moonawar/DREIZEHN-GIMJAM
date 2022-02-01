using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject wave;

    void Awake()
    {
        gameOver.SetActive(false);
    }

    public void GameOver(){
        gameOver.SetActive(true);
        wave.GetComponent<WaveSpawner>().enabled = false;
    }

}
