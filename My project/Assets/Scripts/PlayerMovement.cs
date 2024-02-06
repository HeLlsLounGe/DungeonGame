using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] float vertDist = 2f;
    [SerializeField] float horDist = 2f;

    [SerializeField] float upDist = 2f;
    [SerializeField] float downDist = -2f;
    [SerializeField] float leftDist = -2f;
    [SerializeField] float rightDist = 2f;

    [SerializeField] bool mobileUI = false;
    [SerializeField] Canvas mobileCanvas;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] float moveDelay = 2f;
    float timer = 0f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    bool moveAllow = true;
    bool moving = false;
    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (!mobileUI && moveAllow)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= .1f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .5f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * horDist, 0f, 0f);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .5f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * vertDist, 0f);
                    }
                }
            }
        }

        moveAllow = FindObjectOfType<FightScript>().moveEnabled;
        if (moveAllow)
        {
            mobileCanvas.enabled = true;
            Debug.Log("moveEnabled");
        }
        else if (!moveAllow)
        {
            mobileCanvas.enabled = false;
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
        Debug.Log(moveAllow);
    }
    public void Up()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .5f, whatStopsMovement) && !moving)
        {
            moving = true;
            movePoint.position += new Vector3(0f, upDist, 0f);
        }
    }
    public void Down()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .5f, whatStopsMovement) && !moving)
        {
            moving = true;
            movePoint.position += new Vector3(0f, downDist, 0f);
        }
    }
    public void Left()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .5f, whatStopsMovement) && !moving)
        {
            moving = true;
            movePoint.position += new Vector3(leftDist, 0f, 0f);
        }
    }
    public void Right()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .5f, whatStopsMovement) && !moving)
        {
            moving = true;
            movePoint.position += new Vector3(rightDist, 0f, 0f);
        }
    }
    public void Pause()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
