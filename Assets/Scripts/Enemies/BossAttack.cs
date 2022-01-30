using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] GameObject tentacle;
    Vector3 tentaclePosition, randomPosition;
    float tentacleAttackRadius = 4f, attackCooldown = 2f, nextAttack; 
    int tentacleAmount = 8;


    void Awake()
    {
        
    }

    bool isOverlapping(Vector3 spawnPoint, float collisionRadius){
        Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, collisionRadius, LayerMask.GetMask("Tentacle"));
        return CollisionWithEnemy;
    }

    void TentacleAttack(){
        for (int i = 0; i < tentacleAmount;)
        {
            randomPosition = new Vector3(Random.insideUnitCircle.x *tentacleAttackRadius, 
                                Random.insideUnitCircle.y *tentacleAttackRadius, 0); 

            tentaclePosition = target.position + randomPosition;
            if (isOverlapping(tentaclePosition, 1.3f) == false)
            {
                Instantiate(tentacle, tentaclePosition, target.rotation);
                i++;
            } else {
                continue;
            }
        }
    }
    void Update()
    {
        if (Time.time > nextAttack)
        {
            Invoke("TentacleAttack", 3);
            nextAttack = Time.time + attackCooldown;
        }
    }
}
