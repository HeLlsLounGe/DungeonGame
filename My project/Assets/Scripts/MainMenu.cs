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
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
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
