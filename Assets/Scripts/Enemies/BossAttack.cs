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
    float tentacleAttackRadius = 4f, tentacleAttackCooldown = 3f; 
    float nextTentacleAttack; 
    int tentacleAmount = 8; int loopTries = 0;

    // Laser Attack
    [SerializeField] GameObject laser;
    GameObject laserObj;
    int laserStartPoint, laserEndPoint, pointDistance; 
    Quaternion laserRotation = Quaternion.identity; Vector3 laserPosition;
    float laserAttackCooldown = 5f, nextLaserAttack, zRotation; 


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
            loopTries = 0;
            if (isOverlapping(tentaclePosition, 1.3f) == false)
            {
                Instantiate(tentacle, tentaclePosition, target.rotation);
                i++;
            } else if(loopTries < 100){
                loopTries++;
                continue;
            } else {
                break;
            }
        }
    }

    void GenerateLaser(){
        laserStartPoint = Random.Range(-14, 14);
        laserEndPoint = Random.Range(-14, 14);

        pointDistance = laserEndPoint - laserStartPoint;
        
        laserPosition = new Vector3((laserEndPoint + laserStartPoint)/2, 2.5f, 0f);
        zRotation = (Mathf.Asin(pointDistance/19f)* 360/ 3.14f);

        laserRotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));

        Debug.Log("2");
        GameObject laserObj = Instantiate(laser, laserPosition, laserRotation);
    }
    void LaserAttack(){
        Invoke("GenerateLaser", 0 );
        Invoke("GenerateLaser", 0.5f );
        Invoke("GenerateLaser", 1f );
    }
    void Update()
    {
        if (Time.time > nextTentacleAttack)
        {
            Invoke("TentacleAttack", 1);
            nextTentacleAttack = Time.time + tentacleAttackCooldown;
        }
        if (Time.time > nextLaserAttack)
        {
            Invoke("LaserAttack", 2);
            nextLaserAttack = Time.time + laserAttackCooldown;
        }
    }
}
