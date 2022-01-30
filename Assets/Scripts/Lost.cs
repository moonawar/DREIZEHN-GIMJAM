using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject player;
    public Health health;

    void Awake()
    {
        gameOver.SetActive(false);
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
    }
    private void Update()
    {
        if (health.isDestroyed == true)
        {
            gameOver.SetActive(true);
        }
    }
}
