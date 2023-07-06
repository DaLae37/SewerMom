using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SewerMom : MonoBehaviour
{
    public enum State
    {
        IDLE,
        WALK,
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

    public bool isAnimation = false;
    public bool playerOn = false;
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

    // Update is called once per frame
    void Update()
    {
        if(!isAnimation && playerOn)
        {
            if(StoryManager.instance.controller.mapindex == currentMap)
            {
                if(StoryManager.instance.storyPhase >= 5)
                {
                    state = State.WALK;
                    if (Mathf.Abs(StoryManager.instance.player.transform.position.y - (transform.position.y - 3f)) > 1f)
                    {
                        if (StoryManager.instance.player.transform.position.y < (transform.position.y - 3f))
                        {
                            DirY = -1;
                            DirX = 0;
                        }
                        else
                        {
                            DirY = 1;
                            DirX = 0;
                        }
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, StoryManager.instance.player.transform.position.y + 3f, 0), Time.deltaTime * 6);
                    }
                    else
                    {
                        if (StoryManager.instance.player.transform.position.x < transform.position.x)
                        {
                            DirX = -1;
                            DirY = 0;
                        }
                        else
                        {
                            DirX = 1;
                            DirY = 0;
                        }
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(StoryManager.instance.player.transform.position.x, transform.position.y, 0), Time.deltaTime * 6);
                    }
                }
            }
            else
            {
                if (StoryManager.instance.hideTimer > 2.5f)
                {
                    int before = StoryManager.instance.beforeMap;
                    int after = StoryManager.instance.afterMap;
                    if (before == 3 && after == 4)
                    {
                        currentMap = 4;
                        transform.position = new Vector3(33.5f, -2.3f);
                    }
                    if (before == 3 && after == 5)
                    {
                        currentMap = 5;
                        transform.position = new Vector3(48, -1, 0);
                    }
                    if (before == 3 && after == 11)
                    {
                        currentMap = 11;
                        transform.position = new Vector3(48, -2.3f, 0);
                    }
                    if(before == 5 && after == 6)
                    {
                        currentMap = 6;
                        transform.position = new Vector3(58, 0, 0);
                    }
                    if (before == 5 && after == 7)
                    {
                        currentMap = 7;
                        transform.position = new Vector3(67, -3, 0);
                    }
                    if (before == 7 && after == 8)
                    {
                        currentMap = 8;
                        transform.position = new Vector3(77, 0, 0);
                    }
                    if (before == 9 && after == 10)
                    {
                        currentMap = 10;
                        transform.position = new Vector3(44, 3, 0);
                    }
                    if (before == 7 && after == 5)
                    {
                        currentMap = 5;
                        transform.position = new Vector3(67, -3, 0);
                    }
                }
            }
        }
        if (!playerOn)
        {
            DirX = 0;
            DirY = 0;
        }
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
            isAnimation = true;
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
                isAnimation = false;
            }
        }
        else if(walkOn == 2 && StoryManager.instance.storyPhase == 7)
        {
            playerOn = true;
            isAnimation = true;
            state = State.WALK;
            currentMap = 11;
            DirY = 1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 11f, 0), Time.deltaTime * 6);
            if (transform.position.y > 10.9f)
            {
                currentMap = 12;
                walkOn = 4;
                isAnimation = false;
            }
        }
        else if(walkOn == 4 && StoryManager.instance.storyPhase == 12)
        {
            playerOn = true;
            isAnimation = true;
            state = State.WALK;
            currentMap = 3;
            DirX = -1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(5.5f, transform.position.y, 0), Time.deltaTime * 4);
            if(transform.position.x < 9.5)
            {
                currentMap = 2;
            }
            if (transform.position.x < 5.6f)
            {
                if (StoryManager.instance.player.GetComponent<PlayerMove>().climbladder)
                {
                    DirX = 0;
                    DirY = -1;
                    walkOn = 5;
                }
                else
                {
                    isAnimation = false;
                }
            }
        }
        else if(walkOn == 5 && StoryManager.instance.storyPhase == 12)
        {
            if(!StoryManager.instance.player.GetComponent<PlayerMove>().climbladder && StoryManager.instance.player.GetComponent<Rigidbody2D>().gravityScale == 0)
            {
                isAnimation = false;
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
            isAnimation = true;
            playerOn = false;
            if (!SoundManager.instance.effect.isPlaying)
            {
                SoundManager.instance.PlayEffect(11);
            }
            StoryManager.instance.monster.walkOn = 4444;
        }
    }
}
