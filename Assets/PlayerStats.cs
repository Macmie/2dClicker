using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;

    public static PlayerStats Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    [SerializeField] private float damage;
    [SerializeField] private float health;
    [SerializeField] private float attackSpeed;
    [SerializeField] private string playerName;

    public Sprite playerIcon;


    void Start()
    {
        damage = 1f;
        health = 25f;
        attackSpeed = 1.5f;
    }

    public float GetDamageValue() => damage;

    public float GetHealthValue() => health;

    public float GetAttackSpeedValue() => attackSpeed;

    public string GetPlayerName() => playerName;

}
