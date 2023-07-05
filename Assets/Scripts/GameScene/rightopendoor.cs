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
    public GameObject leftinteraction; // ���ʹ� ����ݱ� �����ϴ� ������Ʈ ��������. (isopen ������ ����)
    leftopendoor leftdoorscript; // ���ʹ� ��ũ��Ʈ ��������
    public GameObject inventorylighter; // ���������� ����
    public GameObject inventorylighterfire; // ���������� ����
    public GameObject fireddoor; // ��Ÿ�� ��

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
                Invoke("destroydoor", 2f); // 2�ʵ� �� ����
            }
            else if (this.transform.parent.name == "traindoor" && triggerOn && thePlayer.IsKeydown && !leftdoorscript.isopen && !fired)
            {
                SoundManager.instance.PlayEffect(9);
                TextLoader.instance.SetText("MainWoodDoor");
                // do nothing : �Ʒ� ������ �Ǹ� �ȵ�. �������� �����ʿ��� ����.
            }
        }
        else if (this.transform.parent.name == "traindoor" && triggerOn && !welcome) // ó�� ���� ������ ����
        {
            SoundManager.instance.PlayEffect(7);
            leftdoorscript.isopen = false;
            rightclose.SetActive(true);
            leftopen.SetActive(false);
            rightopen.SetActive(false);
            blockcollider.SetActive(true);
            welcome = true;
        }
        else if(triggerOn && thePlayer.IsKeydown && !leftdoorscript.isopen && !leftdoorscript.canclose) //������
        {
            SoundManager.instance.PlayEffect(3);
            leftdoorscript.isopen = true;
            leftclose.SetActive(false);
            rightclose.SetActive(false);
            leftopen.SetActive(true);
            blockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if(triggerOn && thePlayer.IsKeydown && leftdoorscript.isopen && leftdoorscript.canclose) //���ݱ�
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
