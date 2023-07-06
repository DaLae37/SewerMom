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
    void Update()
    {
        if (triggerOn && thePlayer.IsKeydown && thePlayer.itemname == "bitecheese")
        {
            TextLoader.instance.SetText("firstusecheese");
        }
        else if (triggerOn && thePlayer.IsKeydown) // ������ ȹ��
        {
            if(this.name == "flashlightitem")
            {
                thePlayer.itemname = "flashlight";
                SoundManager.instance.PlayEffect(23);
            }
            else if(this.name == "keyitem")
            {
                thePlayer.itemname = "goldkey";
                SoundManager.instance.PlayEffect(21);
            }
            else if(this.name == "cheeseitem")
            {
                thePlayer.itemname = "cheese";
                thePlayer.hadCheese = true;
                SoundManager.instance.PlayEffect(22);
            }
            else if(this.name == "lighteritem")
            {
                thePlayer.itemname = "lighter";
                SoundManager.instance.PlayEffect(22);
            }
            inventoryitem.SetActive(true);
            TextLoader.instance.SetText(settext);
            thePlayer.haveitem = true;
            item.SetActive(false);
            this.GetComponent<BoxCollider2D>().enabled = false;
            triggerOn = false;
            
        }
        if(StoryManager.instance.lightOn || this.name == "flashlightitem" && thePlayer.useitem && thePlayer.itemname == "flashlight") // flash ������ ���
        {
            if (!StoryManager.instance.lightOn)
            {
                inventoryitem.SetActive(false);
                thePlayer.haveitem = false;
                thePlayer.itemname = "";
                SoundManager.instance.PlayEffect(10);
            }
            thePlayer.useflash = true;
            thePlayer.transform.GetChild(0).gameObject.SetActive(true); // flashlight 2D Ȱ��
            thePlayer.transform.GetChild(1).gameObject.SetActive(true); // light 2D Ȱ��
            thePlayer.animator.SetBool("lighton", true);
            StoryManager.instance.lightOn = false;
            // todo �� �÷��̾� ���󰡱�
        }
        else if (thePlayer.useitem && thePlayer.itemname == "goldkey") 
        {
            // bottomopendoor�� ������.
            
        }
        else if(thePlayer.useitem && thePlayer.itemname == "cheese")
        {
            // rat �� ������.
        }
        else if(thePlayer.useitem && thePlayer.itemname == "bitecheese")
        {
            // rat �� ������.
        }
        else if(thePlayer.useitem && thePlayer.itemname == "lighter")
        {
            // �������� �����ؾ���.
        }
        else if(thePlayer.useitem && thePlayer.itemname == "lighterfire")
        {
            // ������ �����ʿ� ���� �ڵ����� ����.
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
