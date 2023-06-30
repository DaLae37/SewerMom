using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetBigRat : MonoBehaviour
{
    private PlayerMove thePlayer;
    public bool triggerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOn && thePlayer.IsKeydown)
        {
            TextLoader.instance.SetText("meetbigrat");
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
