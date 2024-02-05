using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] public List <EncounterCont> encounters;
    public EncounterCont curEncounter;
    public float currLvl = 1;
    public int encounterNum;
    [SerializeField] Canvas fightCanv;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            if (encounters.Count > 0)
            {
                if (currLvl == 1)
                {
                    int r = Random.Range(0, 3);
                    curEncounter = encounters[r];
                    encounterNum = r;
                    Debug.Log(r);
                    fightCanv.gameObject.SetActive(true);
                    FindObjectOfType<FightScript>().loadEncounter();
                }
                if (currLvl == 2)
                {
                    int r = Random.Range(3, 6);
                    curEncounter = encounters[r];
                    encounterNum = r;
                    fightCanv.gameObject.SetActive(true);
                    FindObjectOfType<FightScript>().loadEncounter();
                }
                if (currLvl == 3)
                {
                    int r = Random.Range(6, 9);
                    curEncounter = encounters[r];
                    encounterNum = r;
                    fightCanv.gameObject.SetActive(true);
                    FindObjectOfType<FightScript>().loadEncounter();
                }
            }
        }
    }
}
