using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D pelaaja;

    public float moveSpeed = 5f;

    private bool FacingRight = true;

    public Animator anim;

    public int health = 10;


    void Start()
    {
        pelaaja = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(x, y, 0);

        transform.position += input * moveSpeed;


        if (x < 0 && !FacingRight)
        {
            Flip();
        }

        else if (x > 0 && FacingRight)
        {
            Flip();
        }

        if (x == 0 && y == 0)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }

    }

    void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}