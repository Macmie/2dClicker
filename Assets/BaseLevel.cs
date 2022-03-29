using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour
{
    public float globalModifier;
    public List<EnemyInstance> enemies;
    public float huntSpecialization = .2f;

    public List<string> firstName, lastName;


    public string GenerateEnemyName()
    {
        string first = firstName[Random.Range(0, firstName.Count - 1)];
        string second = lastName[Random.Range(0, lastName.Count - 1)];

        return first + " " + second;
    }
}
