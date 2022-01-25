using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 bulletDirection;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<LivingEntity>().DamageSelf();
            Destroy(gameObject);
        } else if (other.gameObject.name != "Player"){
            Destroy(gameObject);
        }
    }
    void Update(){
        bulletDirection = new Vector3(0, bulletSpeed, 0);
        transform.Translate(bulletDirection*Time.deltaTime);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
