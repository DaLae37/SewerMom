using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject inventoryitemcheese;
    public GameObject inventoryitembitecheese;
    private BigRatMove theBigRat;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        theBigRat = FindObjectOfType<BigRatMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(thePlayer.usecheese) && triggerOn && thePlayer.useitem && thePlayer.itemname == "cheese") // 치즈 사용
        {
            if(this.name == "givecheesebigrat")
            {
                TextLoader.instance.SetText("usecheesebigrat");
                theBigRat.blockplayer = false;
                theBigRat.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                TextLoader.instance.SetText("usecheese");
            }
            inventoryitemcheese.SetActive(false);
            thePlayer.itemname = "bitecheese";
            thePlayer.usecheese = true;
            inventoryitembitecheese.SetActive(true);
            thePlayer.useitem = false;
            
        }
        else if(!(thePlayer.usebitecheese) && triggerOn && thePlayer.useitem && thePlayer.itemname == "bitecheese") // 한입 먹어진 치즈 사용
        {
            if (this.name == "givecheesebigrat")
            {
                TextLoader.instance.SetText("usecheesebigrat");
                theBigRat.blockplayer = false;
                theBigRat.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                TextLoader.instance.SetText("usecheese");
            }
            inventoryitembitecheese.SetActive(false);
            thePlayer.itemname = "";
            thePlayer.usebitecheese = true;
            thePlayer.haveitem = false;
            
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
