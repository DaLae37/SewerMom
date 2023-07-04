using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapedoor : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public bool canescape = false;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerOn && thePlayer.IsKeydown && !canescape) //¹® ¸ø¿°
        {
            TextLoader.instance.SetText("cantescape");
        }
        else if(triggerOn && thePlayer.IsKeydown && canescape)
        {
            TextLoader.instance.SetText("ClearDoor");
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
