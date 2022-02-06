using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    float shootCooldown = 1.8f;
    float explodeCooldown = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject explosion;
    Vector3 pos, bulletTranslation; Quaternion rot; float nextFireTime = 0; float nextExpTime = 0;
    public Transform playerRotation;

    public Image Explosive;

    public void Start()
    {
        Explosive.fillAmount = 1;
    }
    
    public void Shoot(){
        Instantiate(bullet, pos, rot);
    }

    public void Boom()
    {
        Instantiate(explosion, pos, rot);
        Explosive.fillAmount = 0;
    }

    public void Update()
    {
        Explosive.fillAmount = 1 - ((nextExpTime - Time.time)/explodeCooldown);
        pos = transform.position;
        rot = playerRotation.rotation;   
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
