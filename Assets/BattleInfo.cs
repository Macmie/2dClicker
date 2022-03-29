using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System;

public class BattleInfo : MonoBehaviour
{
    private enum BattleState { Hunt, Fight }

    #region Fields and variables
    [Header("Level Info")]
    [SerializeField] private BaseLevel currentLvl;
    [SerializeField] private GameObject lvlButtonsRoot;

    [Header("Player Stats")]
    [SerializeField] private PlayerStats player;
    [SerializeField] private TextMeshProUGUI playerDmgVal;
    [SerializeField] private TextMeshProUGUI playerHealthVal;
    [SerializeField] private TextMeshProUGUI playerAtkSpeedVal;
    [SerializeField] private TextMeshProUGUI playerName;

    [Header("Enemy Stats")]
    [SerializeField] private TextMeshProUGUI enemyDmgVal;
    [SerializeField] private TextMeshProUGUI enemyHealthVal;
    [SerializeField] private TextMeshProUGUI enemyAtkSpeedVal;
    [SerializeField] private TextMeshProUGUI enemyName;

    [Header("Icons")]
    [SerializeField] private Sprite playerIcon;
    [SerializeField] private Sprite enemyIcon;

    [Header("Panel Icons")]
    [SerializeField] private Image playerPanel;
    [SerializeField] private Image enemyPanel;

    [Header("Battle states")]
    [SerializeField] private CanvasGroup fight;
    [SerializeField] private CanvasGroup hunt;


    private EnemyInstance enemy;
    private BattleState battleState;
    private Image huntFillAmount;
    #endregion

    private void Start()
    {
        playerDmgVal.text = player.GetStats().Damage.ToString("F4");
        playerHealthVal.text = player.GetStats().Health.ToString("F4");
        playerAtkSpeedVal.text = player.GetStats().AttackSpeed.ToString("F4");
        playerName.text = player.PlayerName;
        playerIcon = player.GetStats().characterIcon;
        playerPanel.sprite = playerIcon;
        fight.alpha = 0f;
        hunt.alpha = 1f;

        huntFillAmount = hunt.GetComponentInChildren<Image>();

        currentLvl = lvlButtonsRoot.GetComponentInChildren<BaseLevel>();

        battleState = BattleState.Hunt;
    }

    //IEnumerator Hunting()
    //{
    //    while (battleState == BattleState.Hunt)
    //    {
    //        fight.alpha = 0f;
    //        hunt.alpha = 1f;
    //        while (huntFillAmount.fillAmount < .98f)
    //        {
    //            LookForEnemy();
    //            yield return null;
    //        }
    //        battleState = BattleState.Fight;
    //    }

    //    while (battleState == BattleState.Fight)
    //    {
    //        fight.alpha = 1f;
    //        hunt.alpha = 0f;
    //        SetupTheEnemy();

    //        while (enemy.GetHealthValue() > 0 && PlayerStats.Instance.GetHealthValue() > 0)
    //        {

    //        }

    //    }

    //}

    //IEnumerator Attack (BaseCharacter attacker, BaseCharacter attacked)



    private void SetupTheEnemy()
    {
        enemy = currentLvl.enemies[Random.Range(0, currentLvl.enemies.Count -1)];
        enemyDmgVal.text = (enemy.GetStats().Damage * currentLvl.globalModifier).ToString();
        enemyHealthVal.text = (enemy.GetStats().Health * currentLvl.globalModifier).ToString();
        enemyAtkSpeedVal.text = (enemy.GetStats().AttackSpeed * currentLvl.globalModifier).ToString();
        enemyName.text = currentLvl.GenerateEnemyName();

        enemyIcon = enemy.GetStats().characterIcon;
    }

    private void LookForEnemy()
    {
        huntFillAmount.fillAmount += Time.deltaTime / currentLvl.huntSpecialization;
    }

    public void SetCurrentLvl(BaseLevel lvl)
    {
        currentLvl = lvl;
    }
}
