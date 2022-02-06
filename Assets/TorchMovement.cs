using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    [SerializeField] private Transform target;
    Vector2 rot; public float angle;
    public PlayerMovement playerMove; 

    void Update()
    {
        rot = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = target.position;
    }
    private void FixedUpdate()
    {

        Vector2 lookDir = rot - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        playerMove.ChangeRotation(angle);
    }
}

