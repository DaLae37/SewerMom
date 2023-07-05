using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapedoor : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    float timer = 0f;
    bool checkTimer = false;
    public bool canescape = false;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(checkTimer && timer > 1.5f)
        {
            StoryManager.instance.Death(0);
        }
        if (triggerOn && thePlayer.IsKeydown && !canescape) //¹® ¸ø¿°
        {
            TextLoader.instance.SetText("cantescape");
        }
        else if(!checkTimer && triggerOn && thePlayer.IsKeydown && canescape)
        {
            TextLoader.instance.SetText("ClearDoor");
            timer = 0f;
            checkTimer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = true;
        }
    }
}
