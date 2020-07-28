using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera Cam;
    public GameObject player;
    private Vector3 offset;

    public Transform firePoint;
    public GameObject bullet;

    private SpriteRenderer gunspriterenderer;

    float firingTimer = 8;
    public float Firerate = 0.2f;
    private float ratetime;

    public void Start()
    {
        Cam = Camera.main;
        offset = transform.position - player.transform.position;
    }

    private void Awake()
    {
        gunspriterenderer = GetComponent<SpriteRenderer>();
    }

    public void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Cam.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(Input.GetMouseButton(0) && Time.time > ratetime)
        {
            ratetime = Time.time + Firerate;
            firingTimer -= Time.deltaTime;
            Instantiate(bullet, firePoint.position, transform.rotation);
            transform.TransformDirection(0, 0, firingTimer);
        }

        if (angle >= -100 && angle <= 90)
        {
            gunspriterenderer.flipY = false;
        }

        else
        {
            gunspriterenderer.flipY = true;
        }
    }
}
