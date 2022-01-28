using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour
{

    [SerializeField] Color32 warnColor, attackColor;
    float warningTime = 1f, disappearTime = 2f;
    SpriteRenderer sprite; CircleCollider2D tentacleCollider;
    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        tentacleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        sprite.color = warnColor;
    }

    void LaunchAttack(){
        sprite.color = attackColor;
        tentacleCollider.enabled = true;
        Invoke("Disappear", disappearTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().DamageSelf(1);
        }
    }
    void Disappear(){
        Destroy(gameObject);
    }
    
    void Update()
    {
        Invoke("LaunchAttack", warningTime);
    }
}
