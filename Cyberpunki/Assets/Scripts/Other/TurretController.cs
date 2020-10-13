using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    public Transform target;
    public Transform Firepoint1;
    public Transform Firepoint2;
    public GameObject turret;
    public GameObject TurretBullet;

    public float turretSpeed;
    public float Firerate;
    private float Ratetime;
    float firingTimer = 8;
    public float range;
    private float lastShotTime = float.MinValue;
    float distance;

    private CircleCollider2D Turretrange;

    void Start()
    {
        Turretrange = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        Vector2 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turretSpeed);
        distance = Vector2.Distance(transform.position,target.position);

        if (distance < range && Time.time > lastShotTime + (3.0f / Firerate))
        {
            Debug.Log("Pelaaja astui tykin läheisyyteen");
            lastShotTime = Time.time;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Ratetime = Time.time + Firerate;
        firingTimer -= Time.deltaTime;
        Instantiate(TurretBullet, Firepoint1.position + Firepoint2.position, transform.rotation);
        transform.TransformDirection(0, 0, firingTimer);
    }

}
