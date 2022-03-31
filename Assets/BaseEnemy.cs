using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemies/CreateNewEnemy")]
public class BaseEnemy : ScriptableObject
{
    public enum SkillUpgrading { DAMAGE, HEALTH, ATK_SPEED, NONE }
    public enum EnemyType { TROLL, GOBLIN, ZOMBIE }

    public EnemyType enemyType;

    [SerializeField] private float damage;
    public float Damage { get => damage;}

    [SerializeField] private float health;
    public float Health { get => health;}

    [SerializeField] private float attackSpeed;
    public float AttackSpeed { get => attackSpeed;}

    public Sprite enemyIcon;

    public SkillUpgrading GetSkillUpgrading()
    {
        switch (enemyType)
        {
            case EnemyType.GOBLIN:
                return SkillUpgrading.ATK_SPEED;
            case EnemyType.TROLL:
                return SkillUpgrading.DAMAGE;
            case EnemyType.ZOMBIE:
                return SkillUpgrading.HEALTH;
            default:
                return SkillUpgrading.NONE;
        }
    }
}
