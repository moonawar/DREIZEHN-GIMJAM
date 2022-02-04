using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health, maxHealth;
    public HealthBar healthBar;
    public Lost lost;
    public Winning win;

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
            if (gameObject.tag == "Player")
            {
                lost.GameOver();
                Destroy(gameObject);
            } 
            else if (gameObject.tag == "Boss")
            {
                win.Update();
            }
            else 
            {
                Debug.Log("Died");
                Destroy(gameObject);
            }
        }
    }
}
