using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HideOn : MonoBehaviour
{
    private float waitforhide = 0; 
    public bool hide = false;
    public bool triggerOn = false;
    public bool canhide = true;
    private PlayerMove thePlayer;
    public GameObject flashLight;
    public GameObject playerlight;
    public GameObject lockerOpen;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOn && thePlayer.IsKeydown && canhide)
        {
            StoryManager.instance.hideTimer = 0f;
            lockerOpen.SetActive(true);
            thePlayer.inhide = true;
            thePlayer.animator.SetFloat("DirX", 0);
            thePlayer.animator.SetFloat("DirY", 1f);    // 라커 들어갈때 위방향보면서 들어감
            SoundManager.instance.PlayEffect(20);
            Invoke("HideonLocker", 1);
            canhide = false;
        }
        if(hide)
        {
            waitforhide += Time.deltaTime;
            if(waitforhide > 1 && thePlayer.IsKeydown && StoryManager.instance.storyPhase != 8)
            {
                thePlayer.animator.SetFloat("DirX", 0);
                thePlayer.animator.SetFloat("DirY", -1f);   // 라커 나올 때 아래 방향 보면서 나옴
                flashLight.SetActive(true);
                playerlight.SetActive(true);
                thePlayer.inhide = false;
                hide = false;
                Invoke("Lockerclose", 0.2f);    // 라커 문 닫힘
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
        }
    }
    private void HideonLocker()
    {
        waitforhide = 0;
        flashLight.SetActive(false);
        playerlight.SetActive(false);
        hide = true;
    }
    private void Lockerclose()
    {
        lockerOpen.SetActive(false);
        canhide = true;
    }
}
