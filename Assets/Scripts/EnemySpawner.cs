using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyScript _enemy;
    [SerializeField] ObjectPool<EnemyScript> _enemyPool;
    [SerializeField] int _spawnCount;
    [SerializeField] int _spawnMaxMax;

    [SerializeField] GameObject _target;
    MoveToTargetFixed _movetotarget;

    [SerializeField]
    [Tooltip("Spawn rate in X per minute")]
    float spawnRate = 10.0f;

    float delay;
    float deltaTime = 0;

    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyScript>(
                                                 CreateEnemy,
                                                 OnTakeEnemyFromPool,
                                                 OnReturnEnemyToPool,
                                                 OnDestory,
                                                 true,
                                                 _spawnCount,
                                                 _spawnMaxMax
                                                 );

        delay = 60 / spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay < deltaTime)
        {
            _enemyPool.Get();
            deltaTime = 0;
        }
        deltaTime += Time.deltaTime;

    }
    EnemyScript CreateEnemy()
    { 
        EnemyScript enemy = Instantiate( _enemy, transform.position, transform.rotation );
        enemy.SetPool(_enemyPool);
        _movetotarget = enemy.GetComponent<MoveToTargetFixed>();
        _movetotarget.SetTarget(_target);
        enemy.gameObject.SetActive( false );
        return enemy;
    }
    void OnTakeEnemyFromPool(EnemyScript enemy)
    {
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;
        enemy.gameObject.SetActive( true );
    }
    void OnReturnEnemyToPool(EnemyScript enemy) => enemy.gameObject.SetActive(false);
   
    void OnDestory(EnemyScript enemy) => Destroy(enemy.gameObject);
}
