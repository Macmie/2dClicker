using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlStructure : MonoBehaviour
{
    [SerializeField] private float globalModifier;
    [SerializeField] private List<BaseEnemy> enemiesOnLvl;
    [SerializeField] private List<string> firstName;
    [SerializeField] private List<string> lastName;
}
