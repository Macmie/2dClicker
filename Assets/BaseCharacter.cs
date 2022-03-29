using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected BaseStats stats;
    public BaseStats GetStats() => stats;
}
