using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ㅡㅡㅡㅡㅡㅡ플레이어 이동ㅡㅡㅡㅡㅡㅡ //
    public float speed; // 움직이는 속도 정의
    private Vector2 vector; // 움직이는 방향 정의
    // ㅡㅡㅡㅡㅡㅡ플레이어 애니메이션ㅡㅡㅡㅡㅡㅡ //
    public Animator animator;

    public bool IsKeydown = false;
    public bool haveitem = false;
    public bool useitem = false;
    public bool useflash = false;
    public bool inhide = false;

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
