using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class friendlyrat : MonoBehaviour
{
    public GameObject cantgo;
    private PlayerMove thePlayer;
    private bool triggerOn = false;
    public int walkOn = 0;
    public Animator animator;
    public GameObject light;
   
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.activeSelf && !StoryManager.instance.flashLight.activeSelf)
        {
            light.SetActive(false);
        }
        if (walkOn == 0 && triggerOn && thePlayer.IsKeydown) //Áã¶û »óÈ£ÀÛ¿ë
        {
            GetComponent<BoxCollider2D>().enabled = false;
            cantgo.SetActive(false);
            TextLoader.instance.SetText("friendlyrat");
            walkOn = 1;
        }
        else if (walkOn == 1)
        {
            animator.SetFloat("DirX", 1);
            animator.SetBool("Walking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11.5f, -0.08f, 0), Time.deltaTime * 7);
            if (transform.position.x > -11.6f)
            {
                animator.SetBool("Walking", false);
                animator.SetFloat("DirX", 0);
                walkOn = 2;
            }
        }
        else if (walkOn == 2 && StoryManager.instance.storyPhase == 2)
        {
            if(transform.position.x < -9.5f || transform.position.x > 9.5f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            animator.SetFloat("DirY", 1);
            animator.SetBool("Walking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11.5f, -3.5f, 0), Time.deltaTime * 10);
            if (transform.position.y < -3.4f)
            {
                animator.SetBool("Walking", false);
                animator.SetFloat("DirY", 0);
                walkOn = 3;
            }
        }
        else if (walkOn == 3 && StoryManager.instance.storyPhase == 2)
        {
            if (transform.position.x < -9.5f || transform.position.x > 9.5f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            animator.SetFloat("DirX", 1);
            animator.SetBool("Walking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(11.5f, -3.5f, 0), Time.deltaTime * 10);
            if (transform.position.x > 11.4f)
            {
                animator.SetFloat("DirX", 0);
                animator.SetBool("Walking", false);
                walkOn = 4;
            }
        }
        else if (walkOn == 4 && StoryManager.instance.storyPhase == 2)
        {
            if (FindObjectOfType<MapController>().mapindex != 3 || transform.position.x > 9.5f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            animator.SetFloat("DirY", -1);
            animator.SetBool("Walking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(11.5f, -0.1f, 0), Time.deltaTime * 10);
            if (transform.position.y > -0.2f)
            {
                animator.SetFloat("DirY", 0);
                animator.SetFloat("DirX", 1);
                animator.SetBool("Walking", false);
                walkOn = 5;
            }
        }
        else if(walkOn == 5 && StoryManager.instance.storyPhase == 2)
        {
            if (FindObjectOfType<MapController>().mapindex == 3)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (walkOn == 5 && StoryManager.instance.storyPhase == 3)
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                animator.SetFloat("DirX", Input.GetAxisRaw("Horizontal"));
                animator.SetBool("Walking", true);
                transform.position = new Vector2(thePlayer.transform.position.x, transform.position.y);
            }
        }
        else if(walkOn == 5 && StoryManager.instance.storyPhase == 4)
        {
            animator.SetBool("Walking", false);
            transform.Rotate(new Vector3(45, 0, -45));
            walkOn = 6;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
        }
    }
}
