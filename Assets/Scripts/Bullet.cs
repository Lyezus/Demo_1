using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{


    [SerializeField] float speed = 1f;
    [SerializeField] float lifespan = 10f;
    public int damage = 10;


    ObjectPool<Bullet> _pool;
    Coroutine _deactivate;


    private void OnEnable()
    {
        lifespan = 10f;
        _deactivate = StartCoroutine(DeactivateBulletAfterTime());
       
    }

    void Update()
    {
        if (lifespan > 0)
        {
            transform.Translate( speed * Time.deltaTime * Vector3.up);
            lifespan -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable) )
        {
            damagable.TakeDamage(damage);
            _pool.Release(this);
        }
    }
    //reference to og bullet pool
    public void SetPool(ObjectPool<Bullet> pool)
    { 
        _pool = pool; 
    }

    IEnumerator DeactivateBulletAfterTime()
    { 
        yield return new WaitForSeconds(lifespan);
        _pool.Release(this);
    }
    
}
