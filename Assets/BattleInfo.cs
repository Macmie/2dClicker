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
    private float modifier, globalModifier;
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
        globalModifier = currentLvl.globalModifier;
        battleState = BattleState.Hunt;

        StartCoroutine(Hunting());
    }

    IEnumerator Hunting()
    {
        while (player.GetStats().Health > 0)
        {
            if (battleState == BattleState.Hunt)
            {
                fight.alpha = 0f;
                hunt.alpha = 1f;
                while (huntFillAmount.fillAmount < .98f)
                {
                    FillTimer(huntFillAmount, currentLvl.huntSpecialization);
                    yield return null;
                }
                huntFillAmount.fillAmount = 1;
                battleState = BattleState.Fight;               
            }

            fight.alpha = 1f;
            hunt.alpha = 0f;
            SetupTheEnemy();
            var playerCorout = StartCoroutine(Attack(player, enemy));
            var enemyCorout = StartCoroutine(Attack(enemy, player));

            while (battleState == BattleState.Fight)
            {
                if (enemy.GetStats().Health > 0 && player.GetStats().Health > 0)
                {
                    yield return null;
                    continue; 
                }

                StopCoroutine(playerCorout);
                StopCoroutine(enemyCorout);
                if (enemy.GetStats().Health == 0)
                {
                    RewardThePlayer();
                }
                else
                {
                    Debug.Log("<color=red>YOU DIED</color>");
                    player.GetStats().Health = 25f;
                }
                battleState = BattleState.Hunt;
            }
            yield return null;
        }

    }

    private void RewardThePlayer()
    {
        switch (enemy.GetEnemyStats.GetSkillUpgrading())
        {
            case BaseEnemy.SkillUpgrading.ATK_SPEED:
                player.GetStats().AttackSpeed *= .001f;
                break;
            case BaseEnemy.SkillUpgrading.DAMAGE:
                player.GetStats().Damage *= .001f;
                break;
            case BaseEnemy.SkillUpgrading.HEALTH:
                player.GetStats().Health *= .001f;
                break;
        }
    }

    IEnumerator Attack(BaseCharacter attacker, BaseCharacter attacked)
    {
        while (attacker.GetStats().Health > 0 && attacked.GetStats().Health > 0)
        {
            var attackerImg = attacker.TryGetComponent<PlayerStats>(out PlayerStats ps) ? playerPanel.GetComponent<Image>() : enemyPanel.GetComponent<Image>();
            attackerImg.fillAmount = 0;
            while (attackerImg.fillAmount < .98f)
            {
                FillTimer(attackerImg, attacker.GetStats().AttackSpeed);
                yield return null;
            }

            AttackTheEnemy(attacker, attacked);
            yield return null;
        }

    }

    private void AttackTheEnemy(BaseCharacter attacker, BaseCharacter attacked)
    {
        attacked.GetStats().Health -= attacker.GetStats().Damage;
    }

    private void SetupTheEnemy()
    {
        modifier = Random.Range(1 - globalModifier, 1 + globalModifier);
        enemy = currentLvl.enemies[Random.Range(0, currentLvl.enemies.Count - 1)];

        enemy.GetStats().AttackSpeed *= modifier;
        enemy.GetStats().Damage *= modifier;
        enemy.GetStats().Health *= modifier;

        enemyDmgVal.text = enemy.GetStats().Damage.ToString();
        enemyHealthVal.text = enemy.GetStats().Health.ToString();
        enemyAtkSpeedVal.text = enemy.GetStats().AttackSpeed.ToString();
        enemyName.text = currentLvl.GenerateEnemyName();

        enemyIcon = enemy.GetStats().characterIcon;

    }

    private void FillTimer(Image img, float parameter)
    {
        img.fillAmount += parameter * Time.deltaTime ;
    }

    public void SetCurrentLvl(BaseLevel lvl)
    {
        currentLvl = lvl;
    }
}
