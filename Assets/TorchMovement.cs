using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    public GameObject Player;
    Vector2 rot;

    void Update()
    {
        rot = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        transform.position = Player.transform.position;

        Vector2 lookDir = rot - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}

