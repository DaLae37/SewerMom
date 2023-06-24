using System.Collections;
using System.Collections.Generic;
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
    public int currentmap = 0; // 맵마다 세팅해줘야함 
    private MapController map;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        map = FindObjectOfType<MapController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerOn && thePlayer.IsKeydown && !isopen && !canclose)
        {
            isopen = true;
            leftclose.SetActive(false);
            rightclose.SetActive(false);
            rightopen.SetActive(true);
            blockcollider.SetActive(false);
            StartCoroutine("closedelay");
        }
        else if (triggerOn && thePlayer.IsKeydown && isopen && canclose)
        {
            isopen = false;
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
        canclose = true;
    }
    IEnumerator opendelay()
    {
        yield return new WaitForSeconds(0.5f);
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
        if (collision.gameObject.name == "fordoor") // 현재 맵 카운팅하기
        {
            map.mapindex = currentmap;
            triggerOn = true;
        }
    }

}
