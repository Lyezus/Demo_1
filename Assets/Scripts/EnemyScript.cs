
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyScript : MonoBehaviour
{

    public HpController _hpController;

    ObjectPool<EnemyScript> _pool;
    // Start is called before the first frame update
    void Start()
    {
        _hpController = GetComponent<HpController>();
        _hpController.OnDeath += Die;
    }

    private void Die(Vector3 poison)
    {
        _pool.Release(this);
    }

    public void SetPool(ObjectPool<EnemyScript> pool) => _pool = pool;

}
