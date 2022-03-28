using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float Damage { get; private set; }
    public float Health { get; private set; }
    public float AttackSpeed { get; private set; }

    [SerializeField] private Image playerIcon;

    // Start is called before the first frame update
    void Start()
    {
        Damage = 1f;
        Health = 25f;
        AttackSpeed = 1.5f;
    }
}
