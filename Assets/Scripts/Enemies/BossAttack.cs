using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    
    // Tentacle Attack
    [SerializeField] GameObject tentacle;
    Vector3 tentaclePosition, randomPosition;
    float tentacleAttackRadius = 4f, attackCooldown = 2f, nextAttack; 
    int tentacleAmount = 8;

    // Laser Attack
    [SerializeField] GameObject laser;
    int laserStartPoint, laserEndPoint, pointDistance; 
    Quaternion laserRotation; Vector3 laserPosition;


    void Awake()
    {
        LaserAttack();
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

    void LaserAttack(){
        laserStartPoint = Random.Range(-14, 14);
        laserEndPoint = Random.Range(-14, 14);

        pointDistance = laserEndPoint - laserStartPoint;
        
        laserPosition = new Vector3((laserEndPoint + laserStartPoint)/2, 2.5f, 0f);
        float zRotation = Mathf.Asin(pointDistance/19f) * Mathf.Rad2Deg;
        laserRotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

        Instantiate(laser, laserPosition, laserRotation);
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
