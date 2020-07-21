using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D pelaaja;

    public float moveSpeed = 5f;

    private bool FacingRight = true;


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
    }

    void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}