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

    public void Start()
    {
        Cam = Camera.main;
        offset = transform.position - player.transform.position;
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

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
        }
    }
}
