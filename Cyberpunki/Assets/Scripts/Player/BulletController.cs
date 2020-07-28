using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rbbullet;

    public int damage = 5;

    void Start()
    {
        
    }


    void Update()
    {
        rbbullet.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (other.tag == "Enemy")
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);
            
        }

        else if (other.tag =="Test")
        {
            Destroy(gameObject);
        }
        
    }
}
