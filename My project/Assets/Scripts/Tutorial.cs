using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] float timeLimit = 7;
    [SerializeField] float glitchStart = 6.5f;
    [SerializeField] AudioClip glitch;
    float timer = 0f;
    float timesPlayed = 0;
    void Update()
    {
        if (timer >= glitchStart && timesPlayed == 0)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(glitch);
            timesPlayed++;
        }
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            LoadNext();
        }
    }
    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
