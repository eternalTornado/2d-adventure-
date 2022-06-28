using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class Damagable : MonoBehaviour, IHittable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            OnHealthValueChanged?.Invoke(currentHealth);
        }
    }

    public UnityEvent OnHit;
    public UnityEvent OnDie;
    public UnityEvent OnAddHealth;

    public UnityEvent<int> OnHealthValueChanged;
    public UnityEvent<int> OnInitializeMaxHealth;

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        GetHit(weaponDamage);
    }

    public void GetHit(int weaponDamage)
    {
        CurrentHealth -= weaponDamage;
        if (CurrentHealth <= 0) OnDie?.Invoke();
        else OnHit?.Invoke();
    }

    public void AddHealth(int value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, maxHealth);
        OnAddHealth?.Invoke();
    }

    public void Initialize(int health)
    {
        maxHealth = health;
        OnInitializeMaxHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
    }
}
