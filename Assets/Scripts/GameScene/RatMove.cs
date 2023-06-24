using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatMove : MonoBehaviour
{
    // �ѤѤѤѤѤ��÷��̾� �̵��ѤѤѤѤѤ� //
    public float speed; // �����̴� �ӵ� ����
    private Vector3 vector; // �����̴� ���� ����

    public int walkCount; // ����Ű �Է½� �̵����� ���ϱ� ���� ��
    private int currentWalkCount; // �̵��� ������ ���� ��

    private bool canMove = true; // ����Ű �̵� �ݺ����� ������ ���� ��

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
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);

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

        // Walking �� ����
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
