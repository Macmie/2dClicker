using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillUpgrading { DAMAGE, HEALTH, ATK_SPEED}
public enum EnemyType { TROLL, GOBLIN, ZOMBIE}

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemies/CreateNewEnemy")]
public class BaseEnemy : ScriptableObject
{
    [SerializeField] private int health, dmg;
    [SerializeField] private float attackSpeed;
    [SerializeField] private Sprite enemyIcon;
    private string enemyName;
    [SerializeField] private EnemyType enemyType;

    private SkillUpgrading skillUpgrading;



    private void Awake()
    {
        switch (enemyType)
        {
            case EnemyType.GOBLIN:
                skillUpgrading = SkillUpgrading.ATK_SPEED;
                break;
            case EnemyType.TROLL:
                skillUpgrading = SkillUpgrading.DAMAGE;
                break;
            case EnemyType.ZOMBIE:
                skillUpgrading = SkillUpgrading.HEALTH;
                break;
        }
    }

    public SkillUpgrading GetUpgradedSkill() => skillUpgrading;

    public void SetEnemyName(string firstName, string lastName)
    {
        enemyName = firstName + " " + lastName;
    }



}
