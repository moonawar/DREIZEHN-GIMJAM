using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform followTarget; 
    [SerializeField] float healtbarOffset;
    Vector3 pos, scale; Quaternion rot; 

    private void Awake() {
        rot = followTarget.rotation;
        transform.position = new Vector3(followTarget.position.x, 
        (followTarget.position.y + transform.localScale.x + healtbarOffset), 
        followTarget.position.z);
    }
    private void Update() {
        transform.rotation = new Quaternion(-rot.x, -rot.y, -rot.z, -rot.w);
    }
}
