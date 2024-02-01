using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    [SerializeField] float healthAmt;
    [SerializeField] float rock;
    [SerializeField] float paper;
    [SerializeField] float scissors;
    [SerializeField] float chanceAtk;
    [SerializeField] float goldDrop;
    [SerializeField] public Sprite enemy;
    [SerializeField] Animator enemyAnimator;
    [SerializeField] List<EncounterCont> encounters;
    EncounterCont currentEncounter;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
