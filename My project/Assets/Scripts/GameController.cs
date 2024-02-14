using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] public float diff = 1;
    [SerializeField] public bool mobileOn = false;
    [SerializeField] AudioClip click;
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
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void DifficultyM()
    {
        diff = 2;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void DifficultyH()
    {
        diff = 3;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void MobileOn()
    {
        mobileOn = true;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void MobileOff()
    {
        mobileOn = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
}
