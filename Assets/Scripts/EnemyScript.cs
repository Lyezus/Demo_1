
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int damage = 3;
    public HpController _hpController;

    ObjectPool<EnemyScript> _pool;
    // Start is called before the first frame update
    void Start()
    {
        _hpController = GetComponent<HpController>();
        _hpController.OnDeath += Die;
    }


    //damage player
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakeDamage(damage);
            _pool.Release(this);
        }
    }

    private void Die(Vector3 poison)
    {
        poison = transform.position;
        UImanagger.score += 1;
        _pool.Release(this);  
    }

    public void SetPool(ObjectPool<EnemyScript> pool) => _pool = pool;

}
