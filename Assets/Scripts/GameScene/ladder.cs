using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ladder : MonoBehaviour
{
    public GameObject ladderblock;
    public bool ismomhere = false;
    private PlayerMove thePlayer;
    private bool triggerOn = false;
    private Vector2 initialpos;
    private Vector2 target;
    private Vector2 vector;
    private bool climing = false;
    private bool candown = false;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerOn && thePlayer.IsKeydown && !thePlayer.climbladder)
        {
            thePlayer.climbladder = true;
            //오르는 함수
            climbset();
            climing = true;
            ladderblock.SetActive(false);
        }
        else if (climing)
        {
            if (thePlayer.transform.position.y < 2.6)
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = vector;
                thePlayer.animator.SetFloat("DirX", 0f);
                thePlayer.animator.SetFloat("DirY", 1f);
                thePlayer.animator.SetBool("Walking", false); // climb 모션으로 대체하기
            }
            else
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                downset();
                if (thePlayer.IsKeydown)
                {
                    candown = true;
                    climing = false;
                }
            }
        }
        else if (candown && !ismomhere)
        {
            if(thePlayer.transform.position.y > -3.18)
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = vector;
                thePlayer.animator.SetFloat("DirX", 0f);
                thePlayer.animator.SetFloat("DirY", 1f);
                thePlayer.animator.SetBool("Walking", false); // climb 모션으로 대체하기
            }
            else
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                ladderblock.SetActive(true);
                thePlayer.climbladder = false;
                candown = false;
            }
        }
        else if(candown && thePlayer.IsKeydown && ismomhere)
        {
            // todo 괴물 있을떄 전철 건너로 점프하기
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
        }
    }
    private void climbset()
    {
        initialpos.Set(5.47f, -3.14f);
        thePlayer.transform.position = initialpos;
        vector.Set(0f, 5f);
    }
    private void downset()
    {
        vector.Set(0f, -5f);
    }
}
