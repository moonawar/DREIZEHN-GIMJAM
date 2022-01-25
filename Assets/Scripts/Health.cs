using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health, maxHealth;
    public HealthBar healthBar;

    private void Awake() {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void DamageSelf(int damage){
        health = health - damage;
        healthBar.SetCurrentHealth(health);
        Debug.Log(gameObject.name + " HP is now " + health);
    }

    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
