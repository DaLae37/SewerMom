using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SewerMom : MonoBehaviour
{
    public enum State
    {
        IDLE,
        WALK,
        FOLLOW_TARGET,
    }
    public enum MoveState
    {
        FRONT,
        LEFT,
        RIGHT,
        BACK,
    }
    public State state;
    public MoveState moveState;

    public GameObject[] animation = new GameObject[12];
    public float animationMaxTime = 0.2f;
    private float animationTimer;
    private int animationSelector;

    public int currentMap = 0;

    public int DirX = 0;
    public int DirY = 0;

    public int walkOn = 0;
    // Start is called before the first frame update
    void Start()
    {
        state = State.IDLE;
        moveState = MoveState.FRONT;
        animationTimer = 0f;
        animationSelector = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("endingResult", 1);
            SceneManager.LoadScene("EndingScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.IDLE)
        {
            if (SoundManager.instance.mom.isPlaying)
            {
                SoundManager.instance.MomOff();
            }
        }
        else
        {
            if (!SoundManager.instance.mom.isPlaying)
            {
                SoundManager.instance.MomOn();
            }
        }

        animationTimer += Time.deltaTime;
        if(DirX == -1)
        {
            moveState = MoveState.LEFT;
        }
        else if (DirX == 1)
        {
            moveState = MoveState.RIGHT;
        }
        else if (DirY == -1)
        {
            moveState = MoveState.FRONT;
        }
        else if (DirY == 1)
        {
            moveState = MoveState.BACK;
        }
        else
        {
            animationSelector = 0;
            state = State.IDLE;
        }
        if(walkOn!= 4444)
        {
            ChangeAnimation();
        }


        if(walkOn == 0 && StoryManager.instance.storyPhase == 4)
        {
            state = State.WALK;
            currentMap = 3;
            DirY = -1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 2.1f, 0), Time.deltaTime * 6);
            if (transform.position.y < 2.2f)
            {
                DirY = 0;
                walkOn = 1;
            }
        }
        else if (walkOn == 1 && StoryManager.instance.storyPhase == 4)
        {
            state = State.WALK;
            DirX = 1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(27.6f, transform.position.y, 0), Time.deltaTime * 6);
            currentMap = 3;
            if (transform.position.x > 27.5f)
            {
                DirX = 0;
                walkOn = 2;
            }
        }
        else if(walkOn == 2 && StoryManager.instance.storyPhase == 7)
        {
            state = State.WALK;
            currentMap = 11;
            DirY = 1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 11f, 0), Time.deltaTime * 6);
            if (transform.position.y > 10.9f)
            {
                currentMap = 11;
                walkOn = 3;
            }
        }
        else if (walkOn == 3 && StoryManager.instance.storyPhase == 7)
        {

        }
        else if(walkOn == 4 && StoryManager.instance.storyPhase == 12)
        {
            state = State.WALK;
            currentMap = 3;
            DirX = -1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(5.5f, transform.position.y, 0), Time.deltaTime * 4);
            if(transform.position.x < 9.5)
            {
                currentMap = 2;
            }
            if (transform.position.x < 5.6f && StoryManager.instance.player.GetComponent<PlayerMove>().climbladder)
            {
                DirX = 0;
                DirY = 1;
                walkOn = 5;
            }
        }
        else if(walkOn == 4444 && StoryManager.instance.storyPhase == 12)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 5);
            if(transform.position.y < -15)
            {
                TextLoader.instance.SetText("MonsterDie");
                StoryManager.instance.storyPhase = 13;
            }
        }
    }

    void ChangeAnimation()
    {
        int animationIndex = 0;
        for(int i=0; i<animation.Length; i++)
        {
            animation[i].SetActive(false);
        }

        if(state == State.IDLE)
        {
            animationIndex = 3 * ((int)moveState) + 1;
        }
        else
        {
            if(animationTimer > animationMaxTime)
            {
                animationTimer = 0;
                animationSelector += 1;
                if (animationSelector >= 3)
                    animationSelector = 0;
            }
            animationIndex = (int)moveState * 3 + animationSelector;
        }
        animation[animationIndex].SetActive(true);
        if (StoryManager.instance.controller.mapindex != currentMap)
        {
            animation[animationIndex].GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            animation[animationIndex].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    void FollowTarget()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Train" && StoryManager.instance.storyPhase == 12)
        {
            SoundManager.instance.PlayEffect(11);
            StoryManager.instance.monster.walkOn = 4444;
        }
    }
}
