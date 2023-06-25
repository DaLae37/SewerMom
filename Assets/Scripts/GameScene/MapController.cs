using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int mapindex = 1; // {시작방 : 1}, {지하철방 : 2}, {메인 방 : 3}, {숨는방1 : 4}, {단서방1 : 5}, {숨는방2 : 6},
                             // {단서방2 : 7}, {열쇠얻는방 : 8}, {열쇠방 : 9}, {라이터방 : 10}, {비밀번호방 : 11}, {커터칼방 : 12}
                             // {탈출 : 13} - 미정
    public GameObject firstroom;
    public GameObject trainroom;
    public GameObject mainroom;
    public GameObject mainbottomroom;
    public GameObject mainrightroom;
    public GameObject mainrightuproom;
    public GameObject rightroom;
    public GameObject rightuproom;
    public GameObject mainuproom;
    public GameObject mainupuproom;
    public GameObject passwardroom;
    public GameObject passwarduproom;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()        //새로운 방 추가될때마다 추가해주기. 초기에는 모든게 비활
    {
        setfirstroom(false);
        settrainroom(false);
        setmainroom(false);

        setmainrightroom(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (mapindex)
        {
            case 1:
                setfirstroom(true);
                settrainroom(false);
                break;
            case 2:
                setfirstroom(false);
                settrainroom(true);
                setmainroom(false);
                break;
            case 3:
                settrainroom(false);
                setmainroom(true);
                setmainrightroom(false);
                break;
            case 4:


                break;
            case 5:
                setmainroom(false);
                setmainrightroom(true);
                break;
        }
    }
    private void setfirstroom(bool active)
    {
        sprite = firstroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
    }
    private void settrainroom(bool active)
    {
        sprite = trainroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            
            sprite.enabled = true;
            for (int i = 0; i < 2; i++)
            {
                trainroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 2; i++)
            {
                trainroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setmainroom(bool active)
    {
        sprite = mainroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 4; i++)
            {
                mainroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 4; i++)
            {
                mainroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setmainrightroom(bool active)
    {
        sprite = mainrightroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 1; i++)
            {
                mainrightroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 1; i++)
            {
                mainrightroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

