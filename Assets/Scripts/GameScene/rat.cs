using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject inventoryitemcheese;
    public GameObject inventoryitembitecheese;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(thePlayer.usecheese) && triggerOn && thePlayer.useitem && thePlayer.itemname == "cheese") // ġ�� ���
        {
            TextLoader.instance.SetText("usecheese");
            inventoryitemcheese.SetActive(false);
            thePlayer.itemname = "bitecheese";
            thePlayer.usecheese = true;
            inventoryitembitecheese.SetActive(true);
            thePlayer.useitem = false;
        }
        else if(!(thePlayer.usebitecheese) && triggerOn && thePlayer.useitem && thePlayer.itemname == "bitecheese") // ���� �Ծ��� ġ�� ���
        {
            TextLoader.instance.SetText("usecheese");
            inventoryitembitecheese.SetActive(false);
            thePlayer.itemname = "";
            thePlayer.usebitecheese = true;
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
