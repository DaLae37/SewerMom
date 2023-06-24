using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ѤѤѤѤѤ��÷��̾� �̵��ѤѤѤѤѤ� //
    public float speed; // �����̴� �ӵ� ����
    private Vector2 vector; // �����̴� ���� ����

    /*
    public float runSpeed; // ShiftŰ �Է½� �����ϴ� �ӵ�
    private float applyRunSpeed; // ShiftŰ �Է½� ����Ǵ� ���� �ӵ�
    private bool applyRunFlag = false; // ShiftŰ �Է¿���
    */

    public int walkCount; // ����Ű �Է½� �̵����� ���ϱ� ���� ��
    private int currentWalkCount; // �̵��� ������ ���� ��

    private bool canMove = true; // ����Ű �̵� �ݺ����� ������ ���� ��

    // �ѤѤѤѤѤ��÷��̾� �浹 �����ѤѤѤѤѤ� //
    // BoxCollider ������Ʈ�� �������� ���� ����
    private BoxCollider2D boxCollider;
    // ����Ұ����� ���̾ �������ֱ� ���� ����

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
        animator.SetBool("lighton", true);
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
             // �Է��� vector ���� �޾� �Ķ���ͷ� ���� -> ���� �Ķ���͸� ������� �ִϸ��̼� ����
             // �����Է½ÿ� ����Ű�� �⺻ 0�� �ǵ��� ����
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