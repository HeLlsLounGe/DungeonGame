using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName ="New Enemy")]
public class EncounterCont : ScriptableObject
{
    [SerializeField] public float health;
    [SerializeField] public float rockChance;
    [SerializeField] public float paperChance;
    [SerializeField] public float scissorsChance;
    [SerializeField] public float atkChance;
    [SerializeField] public float gold;
    [SerializeField] public Sprite enemy;
    [SerializeField] public Animator enemyAnim;

    public float Health(float index)
    {
        return health;
    }
}
