using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] AudioClip click;
    public void Retry()
    {
        SceneManager.LoadScene(0);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
}
