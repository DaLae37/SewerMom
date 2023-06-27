using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject inventoryitem;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOn && thePlayer.IsKeydown) // 아이템 획득
        {
            inventoryitem.SetActive(true);
            TextLoader.instance.SetText("GetFlash");
            thePlayer.haveitem = true;
            item.SetActive(false);
            this.GetComponent<BoxCollider2D>().enabled = false;
            triggerOn = false;
        }
        if (item.name == "Flashlight" && thePlayer.useitem) // flash 아이템 사용
        {
            thePlayer.transform.GetChild(0).gameObject.SetActive(true); // flashlight 2D 활성
            thePlayer.animator.SetBool("lighton", true);
            inventoryitem.SetActive(false);      
            item.SetActive(false);
            thePlayer.haveitem = false;
            thePlayer.useflash = true;
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
