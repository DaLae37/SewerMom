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
