using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class topopendoor : MonoBehaviour
{
    public bool isopen = false;
    public bool canclose = false;
    public bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject topclose;
    public GameObject open;
    public GameObject topblockcollider;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerOn && thePlayer.IsKeydown && !isopen && !canclose) // 문열기
        {
            isopen = true;
            topclose.SetActive(false);
            topblockcollider.SetActive(false);
            open.SetActive(true);
            StartCoroutine("closedelay");
        }
        else if (triggerOn && thePlayer.IsKeydown && isopen && canclose) // 문닫기
        {
            isopen = false;
            topclose.SetActive(true);
            open.SetActive(false);
            topblockcollider.SetActive(true);
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
