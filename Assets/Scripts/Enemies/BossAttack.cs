using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] GameObject tentacle;
    Vector3 tentaclePosition, randomPosition;
    float tentacleAttackRadius = 4f, attackCooldown = 5f, nextAttack; 
    int tentacleAmount = 8;


    void Awake()
    {
        
    }

    void TentacleAttack(){
        for (int i = 0; i < tentacleAmount; i++)
        {
            randomPosition = new Vector3(Random.insideUnitCircle.x *tentacleAttackRadius, 
                                Random.insideUnitCircle.y *tentacleAttackRadius, 0); 

            tentaclePosition = target.position + randomPosition;
            Instantiate(tentacle, tentaclePosition, target.rotation);
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
