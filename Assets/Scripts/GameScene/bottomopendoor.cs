using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class bottomopendoor : MonoBehaviour
{
    public bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject bottomclose;
    public GameObject open;
    public GameObject bottomblockcollider;
    public GameObject topinteraction; // ���ʹ� ����ݱ� �����ϴ� ������Ʈ ��������. (isopen ������ ����)
    topopendoor topdoorscript; // ���ʹ� ��ũ��Ʈ ��������
    public GameObject inventorykey; //������UI ��������
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        topdoorscript = (topopendoor)topinteraction.GetComponent(typeof(topopendoor));
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.parent.name == "mainupdoor" && !(thePlayer.usekey) && triggerOn && thePlayer.IsKeydown) // ����Ⱦ��� �� ����.
        {
            // cant open
            TextLoader.instance.SetText("mainupdoor");
            SoundManager.instance.PlayEffect(9);
        }
        else if (this.transform.parent.name == "mainupdoor" && !(thePlayer.usekey) && triggerOn && thePlayer.useitem && thePlayer.itemname == "goldkey") // ���� ���.
        {
            SoundManager.instance.PlayEffect(18);
            TextLoader.instance.SetText("UseKey");
            thePlayer.haveitem = false;
            inventorykey.SetActive(false);
            thePlayer.itemname = "";
            thePlayer.usekey = true;
        }
        else if (transform.parent.name == "passworddoor" && !StoryManager.instance.passwordClear)
        {
            if (thePlayer.IsKeydown && triggerOn && !StoryManager.instance.passwordClear && !StoryManager.instance.passwordOn)
            {
                thePlayer.IsKeydown = false;
                StoryManager.instance.passwordOn = true;
            }            
        }
        else if (triggerOn && thePlayer.IsKeydown && !topdoorscript.isopen && !topdoorscript.canclose) //������
        {
            SoundManager.instance.PlayEffect(3);
            topdoorscript.isopen = true;
            bottomclose.SetActive(false);
            open.SetActive(true);
            bottomblockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if(triggerOn && thePlayer.IsKeydown && topdoorscript.isopen && topdoorscript.canclose) //���ݱ�
        {
            SoundManager.instance.PlayEffect(4);
            topdoorscript.isopen = false;
            bottomclose.SetActive(true);
            open.SetActive(false);
            bottomblockcollider.SetActive(true);
            StartCoroutine("opendelay");
        }
    }
    IEnumerator closedelay()
    {
        yield return new WaitForSeconds(0.4f);
        topdoorscript.canclose = true;
    }
    IEnumerator opendelay()
    {
        yield return new WaitForSeconds(0.4f);
        topdoorscript.canclose = false;
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
