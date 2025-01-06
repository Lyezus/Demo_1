using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour , IDamagable
{
    public int currentHealth { get => _currentHealth; private set => _currentHealth = value; }
    public int maxHealth { get => _maxHealth; private set => _maxHealth = value; }

    public event IDamagable.TakeDamageEvent OnTakeDamage;
    public event IDamagable.DeathEvent OnDeath;

    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth = 10;


    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Clamp(damage, 0, currentHealth);
        
        currentHealth -= damageTaken;

        if(damageTaken != 0) { OnTakeDamage?.Invoke(damageTaken); }

        if (currentHealth == 0 && damageTaken != 0) { OnDeath?.Invoke(transform.position); }

    }
    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

}
