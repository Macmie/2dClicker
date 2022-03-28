using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;

    public static PlayerStats Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }


    public float Damage { get; private set; }
    public float Health { get; private set; }
    public float AttackSpeed { get; private set; }

    public Sprite PlayerIcon { get; private set; }


    void Start()
    {
        Damage = 1f;
        Health = 25f;
        AttackSpeed = 1.5f;
    }
}
