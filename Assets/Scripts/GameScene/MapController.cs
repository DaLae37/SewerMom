using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int mapindex = 1; // {���۹� : 1}, {����ö�� : 2}, {���� �� : 3}, {���¹�1 : 4}, {�ܼ���1 : 5}, {���¹�2 : 6},
                             // {�ܼ���2 : 7}, {�����¹� : 8}, {����� : 9}, {�����͹� : 10}, {��й�ȣ�� : 11}, {Ŀ��Į�� : 12}
                             // {Ż�� : 13} - ����
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
    void Start()        //���ο� �� �߰��ɶ����� �߰����ֱ�. �ʱ⿡�� ���� ��Ȱ
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

