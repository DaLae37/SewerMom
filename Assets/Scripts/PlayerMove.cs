using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ㅡㅡㅡㅡㅡㅡ플레이어 이동ㅡㅡㅡㅡㅡㅡ //
    public float speed; // 움직이는 속도 정의
    private Vector2 vector; // 움직이는 방향 정의

    /*
    public float runSpeed; // Shift키 입력시 증가하는 속도
    private float applyRunSpeed; // Shift키 입력시 연산되는 증가 속도
    private bool applyRunFlag = false; // Shift키 입력여부
    */

    public int walkCount; // 방향키 입력시 이동값을 정하기 위한 값
    private int currentWalkCount; // 이동값 리셋을 위한 값

    private bool canMove = true; // 방향키 이동 반복실행 방지를 위한 값

    // ㅡㅡㅡㅡㅡㅡ플레이어 충돌 판정ㅡㅡㅡㅡㅡㅡ //
    // BoxCollider 컴포넌트를 가져오기 위해 선언
    private BoxCollider2D boxCollider;
    // 통과불가능한 레이어를 설정해주기 위해 선언

    // ㅡㅡㅡㅡㅡㅡ플레이어 애니메이션ㅡㅡㅡㅡㅡㅡ //
    public Animator animator;



    // ㅡㅡㅡㅡㅡㅡ맵 이동 관련ㅡㅡㅡㅡㅡㅡ //
    static public PlayerMove instance; // instance의 값을 공유
    public string currentMapName; // 현재 맵 이름 저장
    public bool IsKeydown = false;


    public bool inhide = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator.SetBool("lighton", true);
    }
    IEnumerator MoveCoroutine() // 코루틴은 프레임과 상관없이 특정시간동안 작업을 수행할 수 있게 해준다.
                                // 예를 들자면 게임내의 버프효과
    {

        // 키입력이 이뤄지는 동안 실행
        // 코루틴은 한번만 실행되고 입력이 이뤄지면 계속 실행
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            /* 달리기
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }
            */
            if (!inhide)
            {
                vector = Vector2.zero;

                vector.Set(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
                // 입력한 vector 값을 받아 파라미터로 전달 -> 받은 파라미터를 기반으로 애니메이션 실행
                // 동시입력시에 상하키는 기본 0이 되도록 설정
                if (vector.x != 0)
                {
                    vector.y = 0;
                }
                animator.SetFloat("DirX", vector.x);
                animator.SetFloat("DirY", vector.y);
                animator.SetBool("Walking", true);
            }
            


            // walkCount 값만큼 반복하여 객체 이동 walkCount(20) * speed(2.4) = 48px
            // 이동시 Shift키 입력여부 확인하여 Speed 값 추가(2.4)
            while (currentWalkCount < walkCount)
            {
                if (inhide)
                {
                    animator.SetBool("Walking", false);
                    break;
                }
                if (vector.x != 0)
                {
                    GetComponent<Rigidbody2D>().velocity = vector;
                }
                else if (vector.y != 0)
                {
                    GetComponent<Rigidbody2D>().velocity = vector;
                }

                /* //달리기 키 입력시 동시에 실행하여 +2씩 증가하는 효과
                if (applyRunFlag)
                {
                    currentWalkCount++;
                }
                */
                currentWalkCount++;

            }
            // 0.01f의 대기시간을 가지고 while문 반복
            // 이는 컴퓨터의 속도로 인해 객체가 순간이동한 듯한 모션을 자연스럽게 움직이는 형태로 보여지게 해줍니다.
            yield return new WaitForSeconds(0.001667f);

            // 변수 리셋
            currentWalkCount = 0;
        }
        canMove = true;

        // Walking 값 리셋
        animator.SetBool("Walking", false);
    }

    // Update is called once per frame
    void Update()
    {
        

        // 좌측 방향키면 -1, 우측 방향키면 1, 상측 방향키면 1, 하측 방향키면 -1
        // 버튼을 눌렀을 때 실행
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsKeydown = true;
        }
       
        if (Input.GetKeyUp(KeyCode.A))

        {
            IsKeydown = false;
        }



    }
    private void FixedUpdate()
    {
        //if (canMove)
        //{
        //    if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        //    {
        //        canMove = false;
        //        StartCoroutine(MoveCoroutine());
        //    }
        //}
        vector = Vector2.zero;
        if (inhide)
        {
            animator.SetBool("Walking", false);
        }
        else if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
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

        }
    }
}
