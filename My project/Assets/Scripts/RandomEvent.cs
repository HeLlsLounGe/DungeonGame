using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] public List <EncounterCont> encounters;
    public EncounterCont curEncounter;
    [SerializeField] public float currLvl = 3;
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
                    Destroy(collision.gameObject);
                }
                else if (currLvl == 2)
                {
                    int p = Random.Range(3, 6);
                    curEncounter = encounters[p];
                    encounterNum = p;
                    fightCanv.gameObject.SetActive(true);
                    FindObjectOfType<FightScript>().loadEncounter();
                    Destroy(collision.gameObject);
                }
                else if (currLvl == 3)
                {
                    int s = Random.Range(6, 9);
                    curEncounter = encounters[s];
                    encounterNum = s;
                    fightCanv.gameObject.SetActive(true);
                    FindObjectOfType<FightScript>().loadEncounter();
                    Destroy(collision.gameObject);
                }
                Debug.Log(curEncounter);
                Debug.Log(encounterNum);
            }
        }if (collision.gameObject.tag == "Exit")
        {
            currLvl++;
        }
    }
}
