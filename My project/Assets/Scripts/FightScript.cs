using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FightScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] public TextMeshProUGUI playerHealthTXT;

    [SerializeField] public float playerHealth = 5;
    [SerializeField] public float healthAmt;
    [SerializeField] public float rock;
    [SerializeField] public float paper;
    [SerializeField] public float scissors;
    [SerializeField] public float chanceAtk;
    [SerializeField] public float goldDrop;
    [SerializeField] public float playerMax = 5;

    [SerializeField] public Sprite enemy;
    [SerializeField] Image enemyImage;
    [SerializeField] public Animator enemyAnimator;
    [SerializeField] public GameObject ContButton;
    [SerializeField] List<EncounterCont> encounters;
    [SerializeField] Canvas fightCanv;
    EncounterCont currentEncounter;

    [SerializeField] AudioClip click;

    public float playerChoice = 0;
    public float botChoice = 0;
    public bool EnemyChoosing = false;
    public bool moveEnabled = true;

    void Update()
    {
        if (healthAmt <= 0)
        {
            moveEnabled = true;
            fightCanv.enabled = false;
            playerHealth = playerMax;
        }if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
        healthText.text = healthAmt.ToString();
        playerHealthTXT.text = playerHealth.ToString();
        enemyImage.sprite = enemy;
    }
    public void Rock()
    {
        if (!EnemyChoosing)
        {
            playerChoice = 0;
            ContButton.gameObject.SetActive(true);
            Debug.Log("Rock");
        }
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void Paper()
    {
        if (!EnemyChoosing)
        {
            playerChoice = 1;
            ContButton.gameObject.SetActive(true);
            Debug.Log("Paper");
        }
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void Scissors()
    {
        if (!EnemyChoosing)
        {
            playerChoice = 2;
            ContButton.gameObject.SetActive(true);
            Debug.Log("Scissors");
        }
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void EnemyChoose()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        EnemyChoosing = true;
        ContButton.gameObject.SetActive(false);
        int i = Random.Range(0, 100);
        if (i <= chanceAtk)
        {
            int r = Random.Range(0, 100);
            float rockChance = rock;
            float paperChance = paper;
            float scissorsChance = scissors;

            if (r < rockChance)
            {
                botChoice = 0;
                Debug.Log("Enemy Rock");
            }
            else if (r < rockChance + paperChance)
            {
                botChoice = 1;
                Debug.Log("Enemy Paper");
            }
            else
            {
                botChoice = 2;
                Debug.Log("Enemy Scissors");
            }
        }else
        {
            botChoice = 4;
        }
        Fight();
    }
    public void Fight()
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
            if (botChoice == 4)
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
            if (botChoice == 4)
            {
                healthAmt--;
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
            if (botChoice == 4)
            {
                healthAmt--;
            }
        }
        ContButton.gameObject.SetActive(false);
        EnemyChoosing = false;
    }
    public void loadEncounter()
    {
        moveEnabled = false;
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
