using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ѤѤѤѤѤ��÷��̾� �̵��ѤѤѤѤѤ� //
    public float speed; // �����̴� �ӵ� ����
    private Vector2 vector; // �����̴� ���� ����
    // �ѤѤѤѤѤ��÷��̾� �ִϸ��̼ǤѤѤѤѤѤ� //
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
        // ��ȣ�ۿ� Ű
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsKeydown = true;
        }
       
        if (Input.GetKeyUp(KeyCode.A))

        {
            IsKeydown = false;
        }
        // ������ ��� Ű
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
