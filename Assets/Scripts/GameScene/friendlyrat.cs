using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11.5f, -0.08f, 0), Time.deltaTime * 7);
            if (transform.position.x > -11.6f)
            {
                animator.SetFloat("DirX", 0);
                walkOn = 2;
            }
        }
        else if(walkOn == 2 && StoryManager.instance.storyPhase == 2)
        {
            animator.SetFloat("DirY", 1);

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11.5f, -3.5f, 0), Time.deltaTime * 10);
            if (transform.position.y < -3.4f)
            {
                animator.SetFloat("DirY", 0);
                walkOn = 3;
            }
        }
        else if (walkOn == 3 && StoryManager.instance.storyPhase == 2)
        {
            animator.SetFloat("DirX", 1);

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(11.5f, -3.5f, 0), Time.deltaTime * 10);
            if (transform.position.x > 11.4f)
            {
                walkOn = 4;
            }
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
