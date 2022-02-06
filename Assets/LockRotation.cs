using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    public Transform parentTransform;
    
    void Update()
    {
        Quaternion newRot = new Quaternion(parentTransform.rotation.x, parentTransform.rotation.y, 
                                0, parentTransform.rotation.w);
        transform.rotation = newRot;
    }
}
