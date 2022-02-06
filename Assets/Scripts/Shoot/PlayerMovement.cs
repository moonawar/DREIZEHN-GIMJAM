using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    public Rigidbody2D rbTorch;
    public Animator animator;

    public Vector2 pos;
    Vector2 rot;

    // Update is called once per frame
    public void Update()
    {
        pos.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Horizontal")>0)
        {
            animator.SetBool("Kanan", true);
        }
        pos.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("Kiri", true);
        }

        rot = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + pos * moveSpeed * Time.fixedDeltaTime);
        rbTorch.MovePosition(rbTorch.position + pos * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = rot - rbTorch.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbTorch.rotation = angle;
    }
}