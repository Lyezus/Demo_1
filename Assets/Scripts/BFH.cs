using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BFH : MonoBehaviour
{
    [Tooltip("damage per second")]
    [SerializeField] int dps = 20;

    int damage;


    private void OnTriggerStay(Collider other)
    {

        if (other.TryGetComponent(out IDamagable damagable))
        {
            damage = Mathf.RoundToInt(dps * Time.deltaTime);
            if (damage == 0) { damage = 1; };
            damagable.TakeDamage(damage);
        }
    }
    

}
