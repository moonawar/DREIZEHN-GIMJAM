using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float healCooldown = 12f;
    float nextHealTime = 0;
    public int health, maxHealth, heal;
    public HealthBar healthBar; public HeartBar heartBar;
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
        if (heartBar != null)
        {
            heartBar.SetHeartBarDown(health);
        }
        
    }

    public void Heal(){
        health = health + heal;
        if (healthBar != null)
        {
            healthBar.SetCurrentHealth(health);
        }
        if (heartBar != null)
        {
            heartBar.SetHeartBarUp(health);
        }
        
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time > nextHealTime)
            {
                if (health <= 4)
                {
                    Heal();
                    nextHealTime = Time.time + healCooldown;
                }
            }
        }
    }
}
