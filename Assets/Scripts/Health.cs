using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health, maxHealth;
    public HealthBar healthBar;
    public bool isDestroyed = false;
    public Lost lost;

    private void Awake() {
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            
        }
    }

    public void DamageSelf(int damage){
        health = health - damage;
        if (healthBar != null)
        {
            healthBar.SetCurrentHealth(health);
        }
        
        Debug.Log(gameObject.name + " HP is now " + health);
    }

    public void Update()
    {
        if (health <= 0)
        {   
            if (gameObject.tag == "Player"){
                lost.GameOver();
                Destroy(gameObject);
            } else {
                Debug.Log("Died");
                Destroy(gameObject);
            }
        }
    }
}
