using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class rightopendoor : MonoBehaviour
{
    public bool triggerOn = false;
    private PlayerMove thePlayer;
    private bool fired = false;
    private bool welcome = false;
    public GameObject leftclose;
    public GameObject rightclose;
    public GameObject leftopen;
    public GameObject rightopen;
    public GameObject blockcollider;
    public GameObject leftinteraction; // 왼쪽문 열고닫기 판정하는 오브젝트 가져오기. (isopen 공유를 위해)
    leftopendoor leftdoorscript; // 왼쪽문 스크립트 가져오기
    public GameObject inventorylighter; // 나무문에만 쓰임
    public GameObject inventorylighterfire; // 나무문에만 쓰임
    public GameObject fireddoor; // 불타는 문

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        leftdoorscript = (leftopendoor)leftinteraction.GetComponent(typeof(leftopendoor));
    }
    
    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent.name == "traindoor" && welcome)
        {
            if (this.transform.parent.name == "traindoor" && triggerOn && thePlayer.itemname == "lighter")
            {
                inventorylighter.SetActive(false);
                inventorylighterfire.SetActive(true);
                thePlayer.itemname = "lighterfire";
            }
            else if (this.transform.parent.name == "traindoor" && triggerOn && thePlayer.useitem && thePlayer.itemname == "lighterfire")
            {
                TextLoader.instance.SetText("RemoveWoodDoor");
                inventorylighterfire.SetActive(false);
                thePlayer.haveitem = false;
                thePlayer.itemname = "";
                fired = true;
                thePlayer.uselighter = true;
                leftclose.SetActive(false);
                rightclose.SetActive(false);
                leftopen.SetActive(false);
                rightopen.SetActive(false);
                fireddoor.SetActive(true);
                SoundManager.instance.PlayEffect(19);
                Invoke("destroydoor", 2f); // 2초뒤 문 제거
            }
            else if (this.transform.parent.name == "traindoor" && triggerOn && thePlayer.IsKeydown && !leftdoorscript.isopen && !fired)
            {
                SoundManager.instance.PlayEffect(9);
                TextLoader.instance.SetText("MainWoodDoor");
                // do nothing : 아래 로직이 되면 안됨. 나무문은 오른쪽에서 못염.
            }
        }
        else if (this.transform.parent.name == "traindoor" && triggerOn && !welcome) // 처음 메인 룸으로 오면
        {
            SoundManager.instance.PlayEffect(7);
            leftdoorscript.isopen = false;
            rightclose.SetActive(true);
            leftopen.SetActive(false);
            rightopen.SetActive(false);
            blockcollider.SetActive(true);
            welcome = true;
        }
        else if(triggerOn && thePlayer.IsKeydown && !leftdoorscript.isopen && !leftdoorscript.canclose) //문열기
        {
            SoundManager.instance.PlayEffect(3);
            leftdoorscript.isopen = true;
            leftclose.SetActive(false);
            rightclose.SetActive(false);
            leftopen.SetActive(true);
            blockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if(triggerOn && thePlayer.IsKeydown && leftdoorscript.isopen && leftdoorscript.canclose) //문닫기
        {
            SoundManager.instance.PlayEffect(4);
            leftdoorscript.isopen = false;
            rightclose.SetActive(true);
            leftopen.SetActive(false);
            rightopen.SetActive(false);
            blockcollider.SetActive(true);
            StartCoroutine("opendelay");
        }
    }
    IEnumerator closedelay()
    {
        yield return new WaitForSeconds(0.4f);
        leftdoorscript.canclose = true;
    }
    IEnumerator opendelay()
    {
        yield return new WaitForSeconds(0.4f);
        leftdoorscript.canclose = false;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
            if(thePlayer.itemname == "lighterfire")
            {
                thePlayer.itemname = "lighter";
                inventorylighter.SetActive(true);
                inventorylighterfire.SetActive(false);
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
    private void destroydoor()
    {
        blockcollider.SetActive(false);
        fireddoor.SetActive(false);
        SoundManager.instance.PlayEffect(5);
    }
}
