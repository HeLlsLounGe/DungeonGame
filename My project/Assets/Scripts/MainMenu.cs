using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas opt;
    [SerializeField] SpriteRenderer optAnim;
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        opt.enabled = true;
        optAnim.enabled = true;
    }
    public void OptExit()
    {
        opt.enabled = false;
        optAnim.enabled = false;
    }
    public void Back()
    {
        opt.enabled = false;
        optAnim.enabled = false;
    }
    public void Exit()
    {
        
    }
}
