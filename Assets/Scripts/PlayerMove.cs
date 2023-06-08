using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ѤѤѤѤѤ��÷��̾� �̵��ѤѤѤѤѤ� //
    public float speed; // �����̴� �ӵ� ����
    private Vector3 vector; // �����̴� ���� ����

    /*
    public float runSpeed; // ShiftŰ �Է½� �����ϴ� �ӵ�
    private float applyRunSpeed; // ShiftŰ �Է½� ����Ǵ� ���� �ӵ�
    private bool applyRunFlag = false; // ShiftŰ �Է¿���
    */

    public int walkCount; // ����Ű �Է½� �̵����� ���ϱ� ���� ��
    private int currentWalkCount; // �̵��� ������ ���� ��

    public bool canMove = true; // ����Ű �̵� �ݺ����� ������ ���� ��

    // �ѤѤѤѤѤ��÷��̾� �浹 �����ѤѤѤѤѤ� //
    // BoxCollider ������Ʈ�� �������� ���� ����
    private BoxCollider2D boxCollider;
    // ����Ұ����� ���̾ �������ֱ� ���� ����
    public LayerMask layerMask;

    // �ѤѤѤѤѤ��÷��̾� �ִϸ��̼ǤѤѤѤѤѤ� //
    public Animator animator;



    // �ѤѤѤѤѤѸ� �̵� ���äѤѤѤѤѤ� //
    static public PlayerMove instance; // instance�� ���� ����
    public string currentMapName; // ���� �� �̸� ����
    public bool IsKeydown = false;


    public bool inhide = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    IEnumerator MoveCoroutine() // �ڷ�ƾ�� �����Ӱ� ������� Ư���ð����� �۾��� ������ �� �ְ� ���ش�.
                                // ���� ���ڸ� ���ӳ��� ����ȿ��
    {

        // Ű�Է��� �̷����� ���� ����
        // �ڷ�ƾ�� �ѹ��� ����ǰ� �Է��� �̷����� ��� ����
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
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
            if (!inhide)
            {
                vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
                // �Է��� vector ���� �޾� �Ķ���ͷ� ���� -> ���� �Ķ���͸� ������� �ִϸ��̼� ����
                // �����Է½ÿ� ����Ű�� �⺻ 0�� �ǵ��� ����
                if (vector.x != 0)
                {
                    vector.y = 0;
                }
                animator.SetFloat("DirX", vector.x);
                animator.SetFloat("DirY", vector.y);
                animator.SetBool("Walking", true);
            }
            // A->B�� �������� ���� ����� ���������� Null, �������� ���ع��� Return
            RaycastHit2D hit;

            // A����, ĳ������ ���� ��ġ��
            Vector2 start = transform.position;
            // B����, ĳ���Ͱ� �̵��ϰ��� �ϴ� ��ġ�� (��������+�̵���)
            Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);

            // ĳ���Ϳ� BoxCollider�� ����Ǿ� �־� �װ� �浹ü�� �ν��ϹǷ� ���� �� ����
            boxCollider.enabled = false;
            // ������ �߻� (����, ��, ���̾��ũ)
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider.enabled = true;

            // ������ �������� �������� �ʰ� ó��
            if (hit.transform != null)
            {
                break;
            }
            


            // walkCount ����ŭ �ݺ��Ͽ� ��ü �̵� walkCount(20) * speed(2.4) = 48px
            // �̵��� ShiftŰ �Է¿��� Ȯ���Ͽ� Speed �� �߰�(2.4)
            while (currentWalkCount < walkCount)
            {
                if (inhide)
                {
                    
                    animator.SetBool("Walking", false);
                    break;
                }
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

    // Update is called once per frame
    void Update()
    {
        

        // ���� ����Ű�� -1, ���� ����Ű�� 1, ���� ����Ű�� 1, ���� ����Ű�� -1
        // ��ư�� ������ �� ����
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsKeydown = true;
        }
       
        if (Input.GetKeyUp(KeyCode.A))

        {
            IsKeydown = false;
        }

        

    }
    private void LateUpdate()
    {
        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }
    }
}
