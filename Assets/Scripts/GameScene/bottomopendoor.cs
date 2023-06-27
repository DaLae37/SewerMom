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

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        topdoorscript = (topopendoor)topinteraction.GetComponent(typeof(topopendoor));
    }
    
    // Update is called once per frame
    void Update()
    {
        if(triggerOn && thePlayer.IsKeydown && !topdoorscript.isopen && !topdoorscript.canclose) //������
        {
            topdoorscript.isopen = true;
            bottomclose.SetActive(false);
            open.SetActive(true);
            bottomblockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if(triggerOn && thePlayer.IsKeydown && topdoorscript.isopen && topdoorscript.canclose) //���ݱ�
        {
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
