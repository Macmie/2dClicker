using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStats
{
    [SerializeField] private float damage;
    public float Damage { get => damage; set 
        {
            damage = value;
            OnValueChange?.Invoke();
        } }

    [SerializeField] private float health;
    public float Health { get => health; set 
        { 
            health = value;
            OnValueChange?.Invoke();
        } }

    [SerializeField] private float attackSpeed;
    public float AttackSpeed { get => attackSpeed; 
        set 
        { 
            attackSpeed = value;
            OnValueChange?.Invoke();
        } }

    public Sprite characterIcon;

    public event Action OnValueChange = null;
}
