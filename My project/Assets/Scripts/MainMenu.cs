using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas opt;
    [SerializeField] SpriteRenderer optAnim;
    [SerializeField] AudioClip click;
    public void Play()
    {
        SceneManager.LoadScene(0);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void Options()
    {
        opt.enabled = true;
        optAnim.enabled = true;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void OptExit()
    {
        opt.enabled = false;
        optAnim.enabled = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void Back()
    {
        opt.enabled = false;
        optAnim.enabled = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
    }
    public void Exit()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        Application.Quit();
    }
}
