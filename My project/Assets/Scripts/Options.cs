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
        FindObjectOfType<RandomEvent>().Diff = 1;
    }
    public void DiffMed()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        FindObjectOfType<RandomEvent>().Diff = 2;
    }
    public void DiffHard()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        FindObjectOfType<RandomEvent>().Diff = 3;
    }
    public void Back()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        Opt.enabled = false;
    }
}
