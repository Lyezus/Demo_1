using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class AutoShoot : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] ObjectPool<Bullet> _bulletPool;
    [SerializeField] int _bulletCapacity;
    [SerializeField] int _bulletCapacityMax;

 
     
    [SerializeField]
    [Tooltip("Fire rate in shots per minute")]
    float fireRate = 10.0f;

    float delay;
    float deltaTime = 0;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(
                                             CreateBullet,
                                             OnTakeBulletFromPool,
                                             OnReturnBulletFromPool,
                                             OnDistroyBullet,
                                             true,  // collection check -> no duble returns flase is faster nad more dangerous
                                             _bulletCapacity,
                                             _bulletCapacityMax
                                             );
        
        delay =  60 / fireRate;

    }
    // Update is called once per frame
    void Update()
    {
        if (delay < deltaTime)
        {
            _bulletPool.Get();
            deltaTime = 0;
        }
        deltaTime += Time.deltaTime;
    }

    Bullet CreateBullet()
    {
        // spawn new bullet
        Bullet bullet = Instantiate(_bullet, transform.position, transform.rotation);
        //give bullet scipt this pool
        bullet.SetPool(_bulletPool);
        return bullet;
        
    }
    void OnTakeBulletFromPool(Bullet bullet)
    { 
        //set transform and rotation
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        // activate bullet
        bullet.gameObject.SetActive(true);
    }

    void OnReturnBulletFromPool(Bullet bullet)
    { 
        bullet.gameObject.SetActive(false);
    }

    void OnDistroyBullet(Bullet bullet)
    { 
        Destroy(bullet.gameObject);
    }
}



