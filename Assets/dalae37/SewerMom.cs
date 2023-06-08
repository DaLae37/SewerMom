using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerMom : MonoBehaviour
{
    enum State
    {
        IDLE,
        PATROL_IDLE,
        PATROL_WALK,
        TARGET_RUN,
    }
    enum MoveState
    {
        FRONT,
        LEFT,
        RIGHT,
        BACK,
    }
    State state;
    MoveState moveState;

    public GameObject[] animation = new GameObject[12];
    public float animationMaxTime = 0.2f;
    private float animationTimer;
    private int animationSelector;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer += Time.deltaTime;
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            moveState = MoveState.LEFT;
            state = State.PATROL_WALK;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveState = MoveState.RIGHT;
            state = State.PATROL_WALK;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            moveState = MoveState.FRONT;
            state = State.PATROL_WALK;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            moveState = MoveState.BACK;
            state = State.PATROL_WALK;
        }
        else
        {
            animationSelector = 0;
            state = State.IDLE;
        }
        ChangeAnimation();
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
    }
    void ChangeState()
    {

    }
}
