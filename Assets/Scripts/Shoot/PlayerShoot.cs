using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    float shootCooldown = 1.8f;
    [SerializeField] GameObject bullet;
    Vector3 pos, bulletTranslation; Quaternion rot; float nextFireTime = 0;

    void Shoot(){
        Instantiate(bullet, pos, rot);
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
    }
}
