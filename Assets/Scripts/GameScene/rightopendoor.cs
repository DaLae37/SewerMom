using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class rightopendoor : MonoBehaviour
{
    public bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject leftclose;
    public GameObject rightclose;
    public GameObject leftopen;
    public GameObject rightopen;
    public GameObject blockcollider;
    public GameObject leftinteraction; // ���ʹ� ����ݱ� �����ϴ� ������Ʈ ��������. (isopen ������ ����)
    leftopendoor leftdoorscript; // ���ʹ� ��ũ��Ʈ ��������

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        leftdoorscript = (leftopendoor)leftinteraction.GetComponent(typeof(leftopendoor));
    }
    
    // Update is called once per frame
    void Update()
    {
        if(triggerOn && thePlayer.IsKeydown && !leftdoorscript.isopen && !leftdoorscript.canclose) //������
        {
            leftdoorscript.isopen = true;
            leftclose.SetActive(false);
            rightclose.SetActive(false);
            leftopen.SetActive(true);
            blockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if(triggerOn && thePlayer.IsKeydown && leftdoorscript.isopen && leftdoorscript.canclose) //���ݱ�
        {
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
