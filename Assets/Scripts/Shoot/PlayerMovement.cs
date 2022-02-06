using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    float rot; 

    public Vector2 pos;

    public void ChangeRotation(float rotation){
        rot = rotation;
    }

    public void Update()
    {
        pos.x = Input.GetAxisRaw("Horizontal");
        pos.y = Input.GetAxisRaw("Vertical");

        if (rot > -45 && rot < 45)
        {   
            animator.SetBool("Depan", false);
            animator.SetBool("Belakang", true);
            animator.SetBool("Kanan", false);
            animator.SetBool("Kiri", false);
        }
        else if (rot > -135 && rot < -45)
        {
            animator.SetBool("Kanan", true); 
            animator.SetBool("Depan", false);
            animator.SetBool("Belakang", false);
            animator.SetBool("Kiri", false);
                       
        }
        else if (rot > -225 && rot < -135)
        {
            animator.SetBool("Belakang", false);
            animator.SetBool("Depan", true);
            animator.SetBool("Kanan", false);
            animator.SetBool("Kiri", false);
        }
        else
        {
            animator.SetBool("Belakang", false);
            animator.SetBool("Depan", false);
            animator.SetBool("Kanan", false);
            animator.SetBool("Kiri", true);
        }
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + pos * moveSpeed * Time.fixedDeltaTime);
    }
}