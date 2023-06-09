using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ㅡㅡㅡㅡㅡㅡ플레이어 이동ㅡㅡㅡㅡㅡㅡ //
    public float speed; // 움직이는 속도 정의
    public Vector2 vector; // 움직이는 방향 정의
    // ㅡㅡㅡㅡㅡㅡ플레이어 애니메이션ㅡㅡㅡㅡㅡㅡ //
    public Animator animator;
    //사실 여기서 = false로 해도 적용되는건 아님. 인스펙터에서 조정하거나 start함수에서 조정해야함.
    public bool hadCheese = false;
    public bool IsKeydown = false;
    public bool haveitem = false;
    public bool useitem = false;
    public bool useflash = false;
    public bool usekey = false;
    public bool inhide = false;
    public bool usecheese = false;
    public bool usebitecheese = false;
    public bool uselighter = false;
    public string itemname;
    public bool climbladder = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        // 상호작용 키
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsKeydown = true;
        } 
        if (Input.GetKeyUp(KeyCode.A))
        {
            IsKeydown = false;
        }
        // 아이템 사용 키
        if (Input.GetKeyDown (KeyCode.S) && haveitem)
        {
            useitem = true;
        }
        if (Input.GetKeyUp (KeyCode.S))
        {
            useitem = false;
        }

    }
    private void FixedUpdate()
    {
        vector = Vector2.zero;
        if(climbladder)
        {
            // 사다리 오르고 내리는 동안 방향키 조정 x
        }
        else if (inhide)
        {
            SoundManager.instance.PlayerOff();
            GetComponent<Rigidbody2D>().velocity = vector * 0;
            animator.SetBool("Walking", false);
        }
        else if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if(StoryManager.instance != null)
                SoundManager.instance.PlayerOn();
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
             // 입력한 vector 값을 받아 파라미터로 전달 -> 받은 파라미터를 기반으로 애니메이션 실행
             // 동시입력시에 상하키는 기본 0이 되도록 설정
            if (vector.x != 0)
            {
                vector.y = 0;
            }
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);
            GetComponent<Rigidbody2D>().velocity = vector * speed;
        }
        else
        {
            animator.SetBool("Walking", false);
            GetComponent<Rigidbody2D>().velocity = vector * speed;
            if (StoryManager.instance != null)
                SoundManager.instance.PlayerOff();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if (collision.gameObject.GetComponent<SewerMom>().currentMap == StoryManager.instance.controller.mapindex)
            {
                StoryManager.instance.Death(1);
                SoundManager.instance.PlayEffect(12);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "spawner9" && StoryManager.instance.storyPhase == 9)
        {
            collision.gameObject.SetActive(false);
            StoryManager.instance.monster.currentMap = StoryManager.instance.controller.mapindex;
            StoryManager.instance.monster.gameObject.SetActive(true);
            StoryManager.instance.monster.transform.position = new Vector3(86, -3,0);
            StoryManager.instance.monster.playerOn = true;
        }
        if (collision.gameObject.name == "spawner10" && StoryManager.instance.storyPhase == 10)
        {
            collision.gameObject.SetActive(false);
            StoryManager.instance.monster.currentMap = StoryManager.instance.controller.mapindex;
            StoryManager.instance.monster.gameObject.SetActive(true);
            StoryManager.instance.monster.transform.position = new Vector3(38, -3, 0);
            StoryManager.instance.monster.playerOn = true;
        }
        if (collision.gameObject.tag == "Monster")
        {
            if (collision.gameObject.GetComponent<SewerMom>().currentMap == StoryManager.instance.controller.mapindex)
            {
                StoryManager.instance.Death(1);
                SoundManager.instance.PlayEffect(12);
            }
        }
        if (collision.gameObject.tag == "Train")
        {
            StoryManager.instance.Death(3);
        }
        if (collision.tag == "Story")
        {
            if(StoryManager.instance.storyPhase < int.Parse(collision.name)){
                StoryManager.instance.storyPhase = int.Parse(collision.name);
            }
            collision.gameObject.SetActive(false);
        }
    }
}
