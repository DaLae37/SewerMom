using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class leftopendoor : MonoBehaviour
{
    public bool isopen = false;
    public bool canclose = false;
    public bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject leftclose;
    public GameObject rightclose;
    public GameObject leftopen;
    public GameObject rightopen;
    public GameObject blockcollider;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.parent.name == "firstdoor" && !(thePlayer.useflash) && triggerOn && thePlayer.IsKeydown) // ������ ��Ű���� ��������.
        {
            // cant open
            TextLoader.instance.SetText("firstdoor");
        }
        else if (triggerOn && thePlayer.IsKeydown && !isopen && !canclose) // ������
        {
            SoundManager.instance.PlayEffect(3);
            isopen = true;
            leftclose.SetActive(false);
            rightclose.SetActive(false);
            rightopen.SetActive(true);
            blockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if (triggerOn && thePlayer.IsKeydown && isopen && canclose) // ���ݱ�
        {
            SoundManager.instance.PlayEffect(4);
            isopen = false;
            leftclose.SetActive(true);
            leftopen.SetActive(false);
            rightopen.SetActive(false);
            blockcollider.SetActive(true);
            StartCoroutine("opendelay");
        }
    }
    IEnumerator closedelay()
    {
        yield return new WaitForSeconds(0.4f);
        canclose = true;
    }
    IEnumerator opendelay()
    {
        yield return new WaitForSeconds(0.4f);
        canclose = false;
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
