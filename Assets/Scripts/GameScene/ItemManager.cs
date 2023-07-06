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
        else if (triggerOn && thePlayer.IsKeydown) // 아이템 획득
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
        if(StoryManager.instance.lightOn || this.name == "flashlightitem" && thePlayer.useitem && thePlayer.itemname == "flashlight") // flash 아이템 사용
        {
            if (!StoryManager.instance.lightOn)
            {
                inventoryitem.SetActive(false);
                thePlayer.haveitem = false;
                thePlayer.itemname = "";
                SoundManager.instance.PlayEffect(10);
            }
            thePlayer.useflash = true;
            thePlayer.transform.GetChild(0).gameObject.SetActive(true); // flashlight 2D 활성
            thePlayer.transform.GetChild(1).gameObject.SetActive(true); // light 2D 활성
            thePlayer.animator.SetBool("lighton", true);
            StoryManager.instance.lightOn = false;
            // todo 쥐 플레이어 따라가기
        }
        else if (thePlayer.useitem && thePlayer.itemname == "goldkey") 
        {
            // bottomopendoor에 구현됨.
            
        }
        else if(thePlayer.useitem && thePlayer.itemname == "cheese")
        {
            // rat 에 구현됨.
        }
        else if(thePlayer.useitem && thePlayer.itemname == "bitecheese")
        {
            // rat 에 구현됨.
        }
        else if(thePlayer.useitem && thePlayer.itemname == "lighter")
        {
            // 나무문에 구현해야함.
        }
        else if(thePlayer.useitem && thePlayer.itemname == "lighterfire")
        {
            // 나무문 오른쪽에 가면 자동으로 켜짐.
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
