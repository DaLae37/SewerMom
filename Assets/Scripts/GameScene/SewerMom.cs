using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public int currentMap = 0;
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
        if (collision.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("endingResult", 1);
            SceneManager.LoadScene("EndingScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer += Time.deltaTime;
        if(Input.GetAxisRaw("ratHorizontal") < 0)
        {
            moveState = MoveState.LEFT;
            state = State.PATROL_WALK;
        }
        else if (Input.GetAxisRaw("ratHorizontal") > 0)
        {
            moveState = MoveState.RIGHT;
            state = State.PATROL_WALK;
        }
        else if (Input.GetAxisRaw("ratVertical") < 0)
        {
            moveState = MoveState.FRONT;
            state = State.PATROL_WALK;
        }
        else if (Input.GetAxisRaw("ratVertical") > 0)
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
    public float speed; // �����̴� �ӵ� ����
    private Vector3 vector; // �����̴� ���� ����

    public int walkCount; // ����Ű �Է½� �̵����� ���ϱ� ���� ��
    private int currentWalkCount; // �̵��� ������ ���� ��

    private bool canMove = true; // ����Ű �̵� �ݺ����� ������ ���� ��
    IEnumerator MoveCoroutine() // �ڷ�ƾ�� �����Ӱ� ������� Ư���ð����� �۾��� ������ �� �ְ� ���ش�.
                                // ���� ���ڸ� ���ӳ��� ����ȿ��
    {

        // Ű�Է��� �̷����� ���� ����
        // �ڷ�ƾ�� �ѹ��� ����ǰ� �Է��� �̷����� ��� ����
        while (Input.GetAxisRaw("ratHorizontal") != 0 || Input.GetAxisRaw("ratVertical") != 0)
        {
            /* �޸���
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
            // �Է��� vector ���� �޾� �Ķ���ͷ� ���� -> ���� �Ķ���͸� ������� �ִϸ��̼� ����
            // �����Է½ÿ� ����Ű�� �⺻ 0�� �ǵ��� ����
            if (vector.x != 0)
            {
                vector.y = 0;
            }

            // A->B�� �������� ���� ����� ���������� Null, �������� ���ع��� Return

            // A����, ĳ������ ���� ��ġ��
            Vector2 start = transform.position;
            // B����, ĳ���Ͱ� �̵��ϰ��� �ϴ� ��ġ�� (��������+�̵���)
            Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);



            // walkCount ����ŭ �ݺ��Ͽ� ��ü �̵� walkCount(20) * speed(2.4) = 48px
            // �̵��� ShiftŰ �Է¿��� Ȯ���Ͽ� Speed �� �߰�(2.4)
            while (currentWalkCount < walkCount)
            {

                if (vector.x != 0)
                {
                    transform.Translate(vector.x * speed, 0, 0); // �޸��� (speed + applyRunSpeed)
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * speed, 0);
                }

                /* //�޸��� Ű �Է½� ���ÿ� �����Ͽ� +2�� �����ϴ� ȿ��
                if (applyRunFlag)
                {
                    currentWalkCount++;
                }
                */
                currentWalkCount++;

            }
            // 0.01f�� ���ð��� ������ while�� �ݺ�
            // �̴� ��ǻ���� �ӵ��� ���� ��ü�� �����̵��� ���� ����� �ڿ������� �����̴� ���·� �������� ���ݴϴ�.
            yield return new WaitForSeconds(0.001667f);

            // ���� ����
            currentWalkCount = 0;
        }
        canMove = true;
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
