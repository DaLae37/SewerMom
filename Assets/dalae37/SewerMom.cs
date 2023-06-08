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

    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.IDLE;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeState()
    {

    }
}
