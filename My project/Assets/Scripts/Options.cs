using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] Canvas Opt;
    [SerializeField] AudioClip click;
    public void DiffEasy()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        FindObjectOfType<GameController>().DifficultyE();
    }
    public void DiffMed()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        FindObjectOfType<GameController>().DifficultyM();
    }
    public void DiffHard()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        FindObjectOfType<GameController>().DifficultyH();
    }
    public void Back()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        Opt.enabled = false;
    }
}
