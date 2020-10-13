using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sprite;

    private Material matRed;
    private Material matDefault;

    public int health = 10;


    


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sprite.material;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Bullet"))
        {
            sprite.material = matRed;

            if(health <= 0)
            {
                Death();
            }
            else
            {
                Invoke("ResetMaterial", .05f);
            }
        }

       else if (collision.CompareTag  ("Player"))
        {
            sprite.sortingOrder = 3;
        }

    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    void ResetMaterial()
    {
        sprite.material = matDefault;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            sprite.sortingOrder = 0;

        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
