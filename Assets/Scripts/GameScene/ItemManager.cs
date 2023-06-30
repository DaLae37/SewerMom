using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject item;
    
    public GameObject inventoryitem;
    public string settext;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerOn && thePlayer.IsKeydown) // ������ ȹ��
        {
            if(this.name == "flashlightitem")
            {
                thePlayer.itemname = "flashlight";
            }
            else if(this.name == "keyitem")
            {
                thePlayer.itemname = "goldkey";
            }
            inventoryitem.SetActive(true);
            TextLoader.instance.SetText(settext);
            thePlayer.haveitem = true;
            item.gameObject.SetActive(false);
            this.GetComponent<BoxCollider2D>().enabled = false;
            triggerOn = false;
        }
        if(thePlayer.useitem && thePlayer.itemname == "flashlight") // flash ������ ���
        {
            thePlayer.transform.GetChild(0).gameObject.SetActive(true); // flashlight 2D Ȱ��
            thePlayer.animator.SetBool("lighton", true);
            inventoryitem.SetActive(false);
            thePlayer.haveitem = false;
            thePlayer.useflash = true;
            thePlayer.itemname = "";
        }
        else if (thePlayer.useitem && thePlayer.itemname == "goldkey") 
        {
            // bottomopendoor�� ���� todo �۵������ �ȵ�.
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            triggerOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            triggerOn = true;
        }
    }
}
