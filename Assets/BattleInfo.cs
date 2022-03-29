using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleInfo : MonoBehaviour
{
    private enum BattleState { Hunt, Fight}

    [Header("Player Stats")]
    [SerializeField] private TextMeshProUGUI playerDmg;
    [SerializeField] private TextMeshProUGUI playerHealth;
    [SerializeField] private TextMeshProUGUI playerAtkSpeed;
    [SerializeField] private TextMeshProUGUI playerName;

    [Header("Enemy Stats")]
    [SerializeField] private TextMeshProUGUI enemyDmg;
    [SerializeField] private TextMeshProUGUI enemyHealth;
    [SerializeField] private TextMeshProUGUI enemyAtkSpeed;
    [SerializeField] private TextMeshProUGUI enemyName;

    [Header("Icons")]
    [SerializeField] private Sprite playerIcon;
    [SerializeField] private Sprite enemyIcon;
    [Header("Panel Icons")]
    [SerializeField] private Image playerPanel;
    [SerializeField] private Image enemyPanel;

    private BattleState battleState;
    private LvlStructure currentLvl;
    private BaseEnemy enemy;

    private void Start()
    {
        playerDmg.text = PlayerStats.Instance.GetDamageValue().ToString("F4");
        playerHealth.text = PlayerStats.Instance.GetHealthValue().ToString("F4");
        playerAtkSpeed.text = PlayerStats.Instance.GetAttackSpeedValue().ToString("F4");
        playerName.text = PlayerStats.Instance.GetPlayerName();
        playerIcon = PlayerStats.Instance.playerIcon;
        playerPanel.sprite = playerIcon;

        battleState = BattleState.Hunt;
    }


    public void SetCurrentLvl(LvlStructure lvl)
    {
        currentLvl = null;
        currentLvl = lvl;
    }
}
