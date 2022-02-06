using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplode : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 bulletDirection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D[] result = new Collider2D[3];
        Physics2D.OverlapCircle(gameObject.transform.position, 3f, new ContactFilter2D(), result);
        foreach (Collider2D res in result)
        {
            if (res != null){
                if (res.tag == "Enemy")
            {
                res.GetComponent<Health>().DamageSelf(2);
                Destroy(gameObject);
            }
            else if (res.tag == "Tentacle" && res.GetComponent<TentacleAttack>().isOnAttack)
            {
                Destroy(res);
                Destroy(gameObject);
            }
            else if ((res.tag == "Laser" && res.GetComponent<LaserAttack>().isOnAttack == false)
          || (res.tag == "Tentacle" && res.GetComponent<TentacleAttack>().isOnAttack == false))
            {

            }
            else if (res.name != "Player")
            {
                Destroy(gameObject);
            }            
            }

        }
    }
    void Update()
    {
        bulletDirection = new Vector3(0, bulletSpeed, 0);
        transform.Translate(bulletDirection * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
