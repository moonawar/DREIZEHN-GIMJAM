using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 pos;
    Vector2 rot;

    // Update is called once per frame
    void Update()
    {
        pos.x = Input.GetAxisRaw("Horizontal");
        pos.y = Input.GetAxisRaw("Vertical");

        rot = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + pos * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = rot - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}