using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats : BaseCharacter
{
    private static PlayerStats instance;

    public static PlayerStats Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    [SerializeField] private string playerName;
    public string PlayerName { get => playerName; }
   

}
