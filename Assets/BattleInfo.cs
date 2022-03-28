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

    [Header("Enemy Stats")]
    [SerializeField] private TextMeshProUGUI enemyDmg;
    [SerializeField] private TextMeshProUGUI enemyHealth;
    [SerializeField] private TextMeshProUGUI enemyAtkSpeed;

    [Header("Icons")]

    [SerializeField] private Sprite playerIcon;
    [SerializeField] private Sprite enemyIcon;


    private BattleState battleState;

    private void Start()
    {
        playerDmg.text = PlayerStats.Instance.Damage.ToString();
        playerHealth.text = PlayerStats.Instance.Health.ToString();
        playerAtkSpeed.text = PlayerStats.Instance.AttackSpeed.ToString();
        playerIcon = PlayerStats.Instance.PlayerIcon;

        battleState = BattleState.Hunt;
    }
}
