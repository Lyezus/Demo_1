using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(IDamagable))]
public class DeathController : MonoBehaviour
{
    IDamagable damagable;

    private void Awake()
    {
        damagable = GetComponent<IDamagable>();
    }

    private void OnEnable()
    {
        damagable.OnDeath += Damagable_OnDeath;
    }

    private void Damagable_OnDeath(Vector3 poison)
    {
       Debug.Log("Object Died at: " + poison.ToString());
    }
}
