using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public int health;

    public void DamageSelf(){
        health = health - 1;
        Debug.Log("HP is now " + health);
    }
    private void OnCollisionEnter2D(Collision2D other) {

    }
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
