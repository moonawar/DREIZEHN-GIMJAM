using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    Vector2 rot;

    public Vector2 pos;

    // Update is called once per frame
    public void Update()
    {
        pos.x = Input.GetAxisRaw("Horizontal");
        pos.y = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("Kanan", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("Kiri", true);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            animator.SetBool("Depan", true);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetBool("Belakang", true);
        }
        else
        {
            animator.SetBool("Belakang", false);
            animator.SetBool("Depan", true);
            animator.SetBool("Kanan", false);
            animator.SetBool("Kiri", false);
        }
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + pos * moveSpeed * Time.fixedDeltaTime);
    }
}