using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    [SerializeField] public float healthAmt;
    [SerializeField] public float rock;
    [SerializeField] public float paper;
    [SerializeField] public float scissors;
    [SerializeField] public float chanceAtk;
    [SerializeField] public float goldDrop;
    [SerializeField] public Sprite enemy;
    [SerializeField] public Animator enemyAnimator;
    [SerializeField] List<EncounterCont> encounters;
    [SerializeField] Canvas fightCanv;
    EncounterCont currentEncounter;

    public float playerChoice = 0;
    public float botChoice = 0;
    public float playerHealth = 5;
    void Start()
    {
        
    }

    void Update()
    {
        if (playerChoice == 0)
        {
            if (botChoice == 1)
            {
                playerHealth--;
            }
            if (botChoice == 2)
            {
                healthAmt--;
            }
        }
        if (playerChoice == 1)
        {
            if (botChoice == 0)
            {
                healthAmt--;
            }
            if (botChoice == 2)
            {
                playerHealth--;
            }
        }
        if (playerChoice == 2)
        {
            if (botChoice == 0)
            {
                playerHealth--;
            }
            if (botChoice == 1)
            {
                healthAmt--;
            }
        }
        if (healthAmt <= 0)
        {
            fightCanv.gameObject.SetActive(false);
        }
    }
    public void Rock()
    {
        playerChoice = 0;
    }
    public void Paper()
    {
        playerChoice = 1;
    }
    public void Scissors()
    {
        playerChoice = 2;
    }
    public void loadEncounter()
    {
        currentEncounter = encounters[FindObjectOfType<RandomEvent>().encounterNum];
        healthAmt = currentEncounter.health;
        rock = currentEncounter.rockChance;
        paper = currentEncounter.paperChance;
        scissors = currentEncounter.scissorsChance;
        chanceAtk = currentEncounter.atkChance;
        goldDrop = currentEncounter.gold;
        enemy = currentEncounter.enemy;
        enemyAnimator = currentEncounter.enemyAnim;
    }
}
