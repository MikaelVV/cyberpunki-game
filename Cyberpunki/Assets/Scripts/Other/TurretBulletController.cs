using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletController : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rbbullet;

    public int damage = 5;

    void Start()
    {
        Invoke("BulletDestroyer", 1.5f);
    }


    void Update()
    {
        rbbullet.velocity = transform.right * speed;
    }

    void BulletDestroyer()
    {
        Destroy(gameObject);
    }
}
