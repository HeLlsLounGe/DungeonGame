using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] float diff = 1;
    [SerializeField] bool mobileOn = false;
    public int currentLevel;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameController>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        Debug.Log(diff);
        currentLevel = FindObjectOfType<RandomEvent>().currLvl;
    }
    public void DifficultyE()
    {
        diff = 1;
    }
    public void DifficultyM()
    {
        diff = 2;
    }
    public void DifficultyH()
    {
        diff = 3;
    }

    public void PlayerRetry()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
