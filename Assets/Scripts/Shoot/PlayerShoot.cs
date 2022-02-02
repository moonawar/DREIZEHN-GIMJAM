using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    float shootCooldown = 1.8f;
    float explodeCooldown = 3f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject explosion;
    Vector3 pos, bulletTranslation; Quaternion rot; float nextFireTime = 0; float nextExpTime = 0;

    void Shoot(){
        Instantiate(bullet, pos, rot);
    }

    void Boom()
    {
        Instantiate(explosion, pos, rot);
    }

    void Update()
    {
        pos = transform.position;
        rot = transform.rotation;   
        if (Input.GetMouseButtonDown(0)){
            if (Time.time > nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + shootCooldown;
            } 
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time > nextExpTime)
            {
                Boom();
                nextExpTime = Time.time + explodeCooldown;
            }
        }
    }
}
