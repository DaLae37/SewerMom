using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ѤѤѤѤѤ��÷��̾� �̵��ѤѤѤѤѤ� //
    public float speed; // �����̴� �ӵ� ����
    public Vector2 vector; // �����̴� ���� ����
    // �ѤѤѤѤѤ��÷��̾� �ִϸ��̼ǤѤѤѤѤѤ� //
    public Animator animator;
    //��� ���⼭ = false�� �ص� ����Ǵ°� �ƴ�. �ν����Ϳ��� �����ϰų� start�Լ����� �����ؾ���.
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
        if(climbladder)
        {
            // ��ٸ� ������ ������ ���� ����Ű ���� x
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
