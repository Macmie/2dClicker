using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillUpgrading { DAMAGE, HEALTH, ATK_SPEED}
public enum EnemyType { TROLL, GOBLIN, ZOMBIE}

public class BaseEnemy : ScriptableObject
{


    [SerializeField]private int health, dmg;
    [SerializeField] private float attackSpeed;

    [SerializeField] private Sprite enemyIcon;
}
