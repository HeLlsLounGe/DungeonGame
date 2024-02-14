using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] float vertDist = 2f;
    [SerializeField] float horDist = 2f;
    [SerializeField] float upDist = 2f;
    [SerializeField] float downDist = -2f;
    [SerializeField] float leftDist = -2f;
    [SerializeField] float rightDist = 2f;
    [SerializeField] float moveDelay = 2f;

    [SerializeField] bool mobileUI = false;
    [SerializeField] Canvas mobileCanvas;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas opt;
    [SerializeField] Canvas warning;
    Animator MyAnimator;

    [SerializeField] AudioClip click;
    float timer = 0f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    bool moveAllow = true;
    bool moving = false;
    bool paused = false;
    void Start()
    {
        movePoint.parent = null;
        if (mobileUI)
        {
            mobileCanvas.enabled = true;
        }else
        {
            mobileCanvas.enabled = false;
        }
        MyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        moveAllow = FindObjectOfType<FightScript>().moveEnabled;
        mobileUI = FindObjectOfType<GameController>().mobileOn;
        if (mobileUI)
        {
            if (moveAllow)
            {
                mobileCanvas.enabled = true;
                Debug.Log("moveEnabled");
            }
            else if (!moveAllow)
            {
                mobileCanvas.enabled = false;
            }
        }
        else if (!mobileUI)
        {
            mobileCanvas.enabled = false;
        }
        if (!mobileUI && moveAllow && !paused)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= .1f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .5f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * horDist, 0f, 0f);
                        if(Input.GetAxisRaw("Horizontal") == 1)
                        {
                            MyAnimator.SetTrigger("MoveRight");
                        }
                        else if (Input.GetAxisRaw("Horizontal") == -1)
                        {
                            MyAnimator.SetTrigger("MoveLeft");
                        }
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .5f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * vertDist, 0f);
                        if (Input.GetAxisRaw("Vertical") == 1)
                        {
                            MyAnimator.SetTrigger("MoveUp");
                        }
                        else if (Input.GetAxisRaw("Vertical") == -1)
                        {
                            MyAnimator.SetTrigger("MoveDown");
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            Pause();
        }
        if (moving)
        {
            timer += Time.deltaTime;
            if (timer >= moveDelay)
            {
                timer = 0;
                moving = false;
            }
        }
    }
    public void Up()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .5f, whatStopsMovement) && !moving && !paused)
        {
            moving = true;
            movePoint.position += new Vector3(0f, upDist, 0f);
            MyAnimator.SetTrigger("MoveUp");
        }
    }
    public void Down()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .5f, whatStopsMovement) && !moving && !paused)
        {
            moving = true;
            movePoint.position += new Vector3(0f, downDist, 0f);
            MyAnimator.SetTrigger("MoveDown");
        }
    }
    public void Left()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .5f, whatStopsMovement) && !moving && !paused)
        {
            moving = true;
            movePoint.position += new Vector3(leftDist, 0f, 0f);
            MyAnimator.SetTrigger("MoveLeft");
        }
    }
    public void Right()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .5f, whatStopsMovement) && !moving && !paused)
        {
            moving = true;
            movePoint.position += new Vector3(rightDist, 0f, 0f);
            MyAnimator.SetTrigger("MoveRight");
        }
    }
    public void Pause()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
        paused = true;
    }
    public void Resume()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        pauseCanvas.enabled = false;
        warning.enabled = false;
        opt.enabled = false;
        Time.timeScale = 1;
        paused = false;
    }
    public void Options()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        opt.enabled = true;
    }
    public void QuitButton()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        warning.enabled = true;
    }
    public void Quit()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(click);
        SceneManager.LoadScene("MainMenu");
    }
}
