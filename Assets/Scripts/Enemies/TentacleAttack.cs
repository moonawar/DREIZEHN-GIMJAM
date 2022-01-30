using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour
{

    [SerializeField] Color32 warnColor, attackColor;
    float warningTime = 0.5f, disappearTime = 2f;
    bool isOnAttack = false;
    GameObject player;
    SpriteRenderer sprite; CircleCollider2D tentacleCollider;
    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        tentacleCollider = GetComponent<CircleCollider2D>();
        player = GameObject.FindWithTag("Player");
        Invoke("LaunchAttack", warningTime);
    }

    private void Start() {
        sprite.color = warnColor;
    }

    void LaunchAttack(){
        isOnAttack = true;
        sprite.color = attackColor;
        if (tentacleCollider.IsTouching(player.GetComponent<CircleCollider2D>()))
        {
            player.GetComponent<Health>().DamageSelf(1);
        }
        Invoke("Disappear", disappearTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && isOnAttack)
        {
            player.GetComponent<Health>().DamageSelf(1);
        }
    }
    void Disappear(){
        isOnAttack = true;
        Destroy(gameObject);
    }

}
