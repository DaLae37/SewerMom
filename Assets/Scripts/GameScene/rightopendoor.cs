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
    public GameObject leftinteraction; // 왼쪽문 열고닫기 판정하는 오브젝트 가져오기. (isopen 공유를 위해)
    leftopendoor leftdoorscript; // 왼쪽문 스크립트 가져오기

    public int currentmap = 0; // 맵마다 세팅해줘야함 
    private MapController map;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        map = FindObjectOfType<MapController>();
        leftdoorscript = (leftopendoor)leftinteraction.GetComponent(typeof(leftopendoor));
    }
    
    // Update is called once per frame
    void Update()
    {
        if(triggerOn && thePlayer.IsKeydown && !leftdoorscript.isopen && !leftdoorscript.canclose)
        {
            leftdoorscript.isopen = true;
            leftclose.SetActive(false);
            rightclose.SetActive(false);
            leftopen.SetActive(true);
            blockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if(triggerOn && thePlayer.IsKeydown && leftdoorscript.isopen && leftdoorscript.canclose) 
        {
            leftdoorscript.isopen = false;
            leftclose.SetActive(true);
            rightclose.SetActive(true);
            leftopen.SetActive(false);
            rightopen.SetActive(false);
            blockcollider.SetActive(true);
            StartCoroutine("opendelay");
        }
    }
    IEnumerator closedelay()
    {
        yield return new WaitForSeconds(0.5f);
        leftdoorscript.canclose = true;
    }
    IEnumerator opendelay()
    {
        yield return new WaitForSeconds(0.5f);
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
        if (collision.gameObject.name == "fordoor") // 현재 맵 카운팅하기
        {
            map.mapindex = currentmap;
            triggerOn = true;
        }
    }
}
