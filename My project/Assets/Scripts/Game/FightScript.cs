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
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] public RuntimeAnimatorController enemyAnimator;
    [SerializeField] public GameObject ContButton;
    [SerializeField] List<EncounterCont> encounters;
    [SerializeField] Canvas fightCanv;
    [SerializeField] Canvas fightBg;
    EncounterCont currentEncounter;

    [SerializeField] AudioClip click;
    [SerializeField] AudioClip playerHit;
    [SerializeField] AudioClip enemyHit;
    [SerializeField] AudioClip Clash;
    [SerializeField] AudioClip enemyDeath;

    public float playerChoice = 0;
    float counter = 1;
    public float botChoice = 0;
    public bool EnemyChoosing = false;
    public bool moveEnabled = true;
    public bool bossFight = false;

    void Update()
    {
        if (healthAmt <= 0)
        {
            if (counter < 1)
            {
                moveEnabled = true;
                fightCanv.enabled = false;
                fightBg.enabled = false;
                sprite.enabled = false;
                playerHealth = playerMax;
                counter++;
                if (bossFight)
                {
                    SceneManager.LoadScene("BossWin");
                }else
                {
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyDeath);
                }
            }
        }
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
        healthText.text = healthAmt.ToString();
        playerHealthTXT.text = playerHealth.ToString();
        enemyImage.sprite = enemy;
        anim = enemyImage.gameObject.GetComponent<Animator>();
        sprite = enemyImage.gameObject.GetComponent<SpriteRenderer>();

        if (anim.runtimeAnimatorController != enemyAnimator)
        {
            anim.runtimeAnimatorController = enemyAnimator;
        }
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
                Camera.main.GetComponent<AudioSource>().PlayOneShot(playerHit);
            }
            else if (botChoice == 2)
            {
                healthAmt--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyHit);
            }
            else if (botChoice == 4)
            {
                healthAmt--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyHit);
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(Clash);
            }
        }
        if (playerChoice == 1)
        {
            if (botChoice == 0)
            {
                healthAmt--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyHit);
            }
            else if (botChoice == 2)
            {
                playerHealth--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(playerHit);
            }
            else if (botChoice == 4)
            {
                healthAmt--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyHit);
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(Clash);
            }
        }
        if (playerChoice == 2)
        {
            if (botChoice == 0)
            {
                playerHealth--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(playerHit);
            }
            else if (botChoice == 1)
            {
                healthAmt--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyHit);
            }
            else if (botChoice == 4)
            {
                healthAmt--;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(enemyHit);
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(Clash);
            }
        }
        ContButton.gameObject.SetActive(false);
        EnemyChoosing = false;
    }
    public void loadEncounter()
    {
        counter--;
        moveEnabled = false;
        sprite.enabled = true;
        fightBg.enabled = true;
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
    public void fightingBoss()
    {
        bossFight = true;
    }
}
