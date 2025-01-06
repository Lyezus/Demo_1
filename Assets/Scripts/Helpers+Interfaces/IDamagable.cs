using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagable 
{
    public int currentHealth { get; }
    public int maxHealth { get; }

    public delegate void TakeDamageEvent(int damage);
    public event TakeDamageEvent OnTakeDamage;

    public delegate void DeathEvent(Vector3 poison);
    public event DeathEvent OnDeath;

    public void TakeDamage(int damage); 

}
