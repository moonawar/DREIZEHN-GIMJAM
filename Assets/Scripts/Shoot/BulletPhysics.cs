using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 bulletDirection;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<Health>().DamageSelf(1);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Tentacle" && other.gameObject.GetComponent<TentacleAttack>().isOnAttack) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else if ((other.gameObject.tag == "Laser" && other.gameObject.GetComponent<LaserAttack>().isOnAttack == false)
        || (other.gameObject.tag == "Tentacle" && other.gameObject.GetComponent<TentacleAttack>().isOnAttack == false)) {
            
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
