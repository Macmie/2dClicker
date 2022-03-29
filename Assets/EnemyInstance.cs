using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : BaseCharacter
{
    [SerializeField] private BaseEnemy enemy;

    private void Start()
    {
        stats.Damage = enemy.Damage;
        stats.Health = enemy.Health;
        stats.AttackSpeed = enemy.AttackSpeed;
    }
}
