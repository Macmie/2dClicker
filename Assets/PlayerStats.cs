using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats : BaseCharacter
{
    #region Singleton
    private static PlayerStats instance;

    public static PlayerStats Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }
    #endregion

    [SerializeField] private string playerName;
    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; set {
            maxHealth = value;
        } }
    public string PlayerName { get => playerName; }
   

}
