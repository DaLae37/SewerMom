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
            if (thePlayer.transform.position.y < 2.6) // 사다리 올라가기
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = vector;
                thePlayer.animator.SetFloat("DirX", 0f);
                thePlayer.animator.SetFloat("DirY", 1f);
                thePlayer.animator.SetBool("climbing", true); // climb 모션으로 대체하기
            }
            else // 사다리 다 올라갔다면.
            {
                thePlayer.animator.SetBool("climbcomplete", true);
                ladderblock.SetActive(true);
                thePlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                downset();
                if (thePlayer.IsKeydown && !ismomhere) // 그냥 내려갈때 충돌체 없애주기
                {
                    ladderblock.SetActive(false);
                    candown = true;
                    climing = false;
                }
                else if (thePlayer.IsKeydown && ismomhere) // 점프해서 갈땐 충돌체 안없애줘도됨.
                {
                    candown = true;
                    climing = false;
                    thePlayer.GetComponent<Rigidbody2D>().gravityScale = 1;
                    thePlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
                }
                   
            }
        }
        else if (candown && !ismomhere) // 괴물이 없을때 그냥 내려오기
        {
            if(thePlayer.transform.position.y > -3.18)
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = vector;
                thePlayer.animator.SetFloat("DirX", 0f);
                thePlayer.animator.SetFloat("DirY", 1f);
                thePlayer.animator.SetBool("climbcomplete", false);
            }
            else
            {
                thePlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                thePlayer.animator.SetBool("climbing", false);
                ladderblock.SetActive(true);
                thePlayer.climbladder = false;
                candown = false;
            }
        }
        else if(candown && ismomhere)
        {
            // todo 괴물 있을떄 전철 건너로 점프하기
            if (thePlayer.transform.position.y > -0.3)
            {
                thePlayer.animator.SetBool("jump", true);
                thePlayer.animator.SetBool("climbing", false);
                thePlayer.animator.SetBool("climbcomplete", false);
                thePlayer.animator.SetFloat("DirX", -1f);
                thePlayer.animator.SetFloat("DirY", 0f);
                thePlayer.animator.SetBool("Walking", true);
                
            }
            else
            {
                thePlayer.animator.SetBool("jump", false);
                thePlayer.animator.SetBool("Walking", false);
                thePlayer.GetComponent<Rigidbody2D>().gravityScale = 0;
                thePlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                thePlayer.climbladder = false;
                candown = false;
            }
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
