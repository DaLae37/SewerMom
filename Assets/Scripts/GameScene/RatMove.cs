using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatMove : MonoBehaviour
{
    // ㅡㅡㅡㅡㅡㅡ플레이어 이동ㅡㅡㅡㅡㅡㅡ //
    public float speed; // 움직이는 속도 정의
    private Vector3 vector; // 움직이는 방향 정의

    public int walkCount; // 방향키 입력시 이동값을 정하기 위한 값
    private int currentWalkCount; // 이동값 리셋을 위한 값

    private bool canMove = true; // 방향키 이동 반복실행 방지를 위한 값

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveCoroutine() // 코루틴은 프레임과 상관없이 특정시간동안 작업을 수행할 수 있게 해준다.
                                // 예를 들자면 게임내의 버프효과
    {

        // 키입력이 이뤄지는 동안 실행
        // 코루틴은 한번만 실행되고 입력이 이뤄지면 계속 실행
        while (Input.GetAxisRaw("ratHorizontal") != 0 || Input.GetAxisRaw("ratVertical") != 0)
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
            vector.Set(Input.GetAxisRaw("ratHorizontal"), Input.GetAxisRaw("ratVertical"), transform.position.z);
            // 입력한 vector 값을 받아 파라미터로 전달 -> 받은 파라미터를 기반으로 애니메이션 실행
            // 동시입력시에 상하키는 기본 0이 되도록 설정
            if (vector.x != 0)
            {
                vector.y = 0;
            }
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);

            // A->B로 레이저를 쏴서 제대로 도착했을때 Null, 막혔을때 방해물이 Return

            // A지점, 캐릭터의 현재 위치값
            Vector2 start = transform.position;
            // B지점, 캐릭터가 이동하고자 하는 위치값 (시작지점+이동값)
            Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);



            // walkCount 값만큼 반복하여 객체 이동 walkCount(20) * speed(2.4) = 48px
            // 이동시 Shift키 입력여부 확인하여 Speed 값 추가(2.4)
            while (currentWalkCount < walkCount)
            {
                
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * speed, 0, 0); // 달리기 (speed + applyRunSpeed)
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * speed, 0);
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

    private void LateUpdate()
    {
        if (canMove)
        {
            if (Input.GetAxisRaw("ratHorizontal") != 0 || Input.GetAxisRaw("ratVertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }
    }
}
