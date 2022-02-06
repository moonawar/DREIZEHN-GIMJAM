using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMovement : MonoBehaviour
{
    public GameObject Player;
    
    void Follow()
    {
        transform.position = Player.transform.position;
    }
}

