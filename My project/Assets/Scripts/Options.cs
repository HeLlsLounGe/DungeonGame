using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] Canvas Opt;
    [SerializeField] AudioClip click;
    public void DiffEasy()
    {
        FindObjectOfType<GameController>().DifficultyE();
    }
    public void DiffMed()
    {
        FindObjectOfType<GameController>().DifficultyM();
    }
    public void DiffHard()
    {
        FindObjectOfType<GameController>().DifficultyH();
    }
    public void Back()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        Opt.enabled = false;
    }
    public void MobileOn()
    {
        FindObjectOfType<GameController>().MobileOn();
    }
    public void MobileOff()
    {
        FindObjectOfType<GameController>().MobileOff();
    }
}
