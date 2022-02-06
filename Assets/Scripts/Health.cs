using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float healCooldown = 12f;
    float nextHealTime = 0;
    public int health, maxHealth, heal;
    public HealthBar healthBar; public HeartBar heartBar;
    public Lost lost;
    public Winning win;
    public Image Healing;

    private void Awake() {
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            
        }
    }
    
    public void Start()
    {
        if (gameObject.tag == "Player"){
            Healing.fillAmount = 1;
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
        Healing.fillAmount = 0;
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
        if (gameObject.tag == "Player"){
            Healing.fillAmount = 1 - ((nextHealTime - Time.time)/healCooldown);
        }
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
                Invoke("DestroySelf", 0.8f);

            }
            else 
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.tag == "Player"){
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

    public void DestroySelf(){
        Destroy(gameObject);
    }
}
