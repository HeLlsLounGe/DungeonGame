using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName ="New Enemy")]
public class EncounterCont : ScriptableObject
{
    [SerializeField] float health;
    [SerializeField] float rockChance;
    [SerializeField] float paperChance;
    [SerializeField] float scissorsChance;
    [SerializeField] float atkChance;
    [SerializeField] float gold;
    [SerializeField] public Sprite enemy;
    [SerializeField] Animator enemyAnim;

    public float Health(float index)
    {
        return health;
    }
}
