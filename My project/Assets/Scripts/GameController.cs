using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] public float diff = 1;
    [SerializeField] public bool mobileOn = false;
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
    public void MobileOn()
    {
        mobileOn = true;
    }
    public void MobileOff()
    {
        mobileOn = false;
    }
}
