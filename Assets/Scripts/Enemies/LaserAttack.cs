using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    // Variables
    [SerializeField] Color32 warnColor, attackColor;
    float warningTime = 1f, disappearTime = 1f;
    bool isOnAttack = false;
    
    // Component
    SpriteRenderer sprite; BoxCollider2D laserCollider;

    // References
    GameObject player;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        laserCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        Invoke("LaunchAttack", warningTime);
    }

    void Start(){
        sprite.color = warnColor;
    }

    void LaunchAttack(){
        isOnAttack = true;
        sprite.color = attackColor;
        if (laserCollider.IsTouching(player.GetComponent<CircleCollider2D>()))
        {
            player.GetComponent<Health>().DamageSelf(1);
        }
        Invoke("Disappear", disappearTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && isOnAttack == true)
        {
            player.GetComponent<Health>().DamageSelf(1);
        }
    }

    void Disappear(){
        Destroy(gameObject);
    }

}
