using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public TurretController turretController;

    void Awake()
    {
        turretController = gameObject.GetComponentInParent<TurretController>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if(turretController.wakeRange > 6)
            {
                
            }
            else
            {
             
            }
        }
    }
}
