using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] public List <EncounterCont> encounters;
    [SerializeField] public float currLvl = 3;
    [SerializeField] public float Diff = 1f;
    [SerializeField] Canvas fightCanv;
    public EncounterCont curEncounter;
    public int encounterNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            int i = Random.Range(0, 100);
            if (encounters.Count >= 0)
            {
                if (Diff == 1)
                {
                    if (i >= 50)
                    {
                        if (currLvl == 1)
                        {
                            int r = Random.Range(0, 3);
                            curEncounter = encounters[r];
                            encounterNum = r;
                            Debug.Log(r);
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                        else if (currLvl == 2)
                        {
                            int p = Random.Range(3, 6);
                            curEncounter = encounters[p];
                            encounterNum = p;
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                        else if (currLvl == 3)
                        {
                            int s = Random.Range(6, 9);
                            curEncounter = encounters[s];
                            encounterNum = s;
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                    }
                }
                else if (Diff == 2)
                {
                    if (i >= 75)
                    {
                        if (currLvl == 1)
                        {
                            int r = Random.Range(9, 12);
                            curEncounter = encounters[r];
                            encounterNum = r;
                            Debug.Log(r);
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                        else if (currLvl == 2)
                        {
                            int p = Random.Range(12, 15);
                            curEncounter = encounters[p];
                            encounterNum = p;
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                        else if (currLvl == 3)
                        {
                            int s = Random.Range(15, 18);
                            curEncounter = encounters[s];
                            encounterNum = s;
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                    }
                }
                else if (Diff == 3)
                {
                    if (i >= 100)
                    {
                        if (currLvl == 1)
                        {
                            int r = Random.Range(18, 21);
                            curEncounter = encounters[r];
                            encounterNum = r;
                            Debug.Log(r);
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                        else if (currLvl == 2)
                        {
                            int p = Random.Range(21, 24);
                            curEncounter = encounters[p];
                            encounterNum = p;
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                        else if (currLvl == 3)
                        {
                            int s = Random.Range(24, 27);
                            curEncounter = encounters[s];
                            encounterNum = s;
                            fightCanv.enabled = true;
                            FindObjectOfType<FightScript>().loadEncounter();
                        }
                    }
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Exit")
        {
            currLvl++;
        }
    }
}
