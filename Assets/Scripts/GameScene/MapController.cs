using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int mapindex = 1; // {���۹� : 1}, {����ö�� : 2}, {���� �� : 3}, {���¹�1 : 4}, {�ܼ���1 : 5}, {���¹�2 : 6},
                             // {�ܼ���2 : 7}, {�����¹� : 8}, {����� : 9}, {�����͹� : 10}, {��й�ȣ�� : 11}, {Ŀ��Į�� : 12}
                             // {Ż�� : 13} - ����
    public GameObject firstroom; // 1
    public GameObject trainroom; // 2
    public GameObject mainroom; // 3
    public GameObject mainbottomroom; // 4
    public GameObject mainrightroom; // 5
    public GameObject mainrightuproom; // 6
    public GameObject rightroom; // 7
    public GameObject rightuproom; // 8
    public GameObject mainuproom; // 9
    public GameObject mainupuproom; // 10
    public GameObject passwardroom; // 11
    public GameObject passwarduproom; // 12
    private SpriteRenderer sprite;
    public GameObject firstdoor;
    // mainroom�� ����� ���� //
    public GameObject traindoor;
    public GameObject mainpassworddoor;
    public GameObject mainbottomdoor;
    public GameObject mainupdoor;
    public GameObject mainrightdoor;
    //-----------------------//
    public GameObject mainrightupdoor;
    public GameObject mainrightrightdoor;
    public GameObject rightupdoor;
    // Start is called before the first frame update
    void Start()        //���ο� �� �߰��ɶ����� �߰����ֱ�. �ʱ⿡�� ���� ��Ȱ
    {
        setfirstroom(false);
        settrainroom(false);
        setmainroom(false);
        setmainbottomroom(false);
        setmainrightroom(false);
        setrightroom(false);
        // door
        setdoor(false, firstdoor);
        setdoor(false, traindoor);
        setdoor(false, mainrightdoor);
        setdoor(false, mainrightrightdoor);
        settopbottomdoor(false, mainbottomdoor);
        settopbottomdoor(false, mainpassworddoor);
        settopbottomdoor(false, mainupdoor);
        settopbottomdoor(false, mainrightupdoor);
        settopbottomdoor(false, rightupdoor);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (mapindex)
        {
            case 1: // firstroom
                setfirstroom(true);
                settrainroom(false);

                setdoor(true,firstdoor);
                setdoor(false, traindoor);
                break;
            case 2: // trainroom
                
                setfirstroom(false);
                settrainroom(true);
                setmainroom(false);

                setdoor(true, firstdoor);
                setdoor(true, traindoor);
                setdoor(false, mainrightdoor);
                settopbottomdoor(false, mainbottomdoor);
                settopbottomdoor(false, mainpassworddoor);
                settopbottomdoor(false, mainupdoor);
                /* todo - ����� �� ���� - main ���� �Ⱥ��̰� ���ֱ�*/
                break;
            case 3: // mainroom
                settrainroom(false);
                setmainroom(true);
                setmainrightroom(false);
                setmainbottomroom(false);
                /*To do - main�� ����� ���� �� �� ���� ���� false���ֱ�*/

                /*todo - main�� �ִ� ���� true���ֱ�*/
                setdoor(false, firstdoor);
                setdoor(true, traindoor);
                setdoor(true, mainrightdoor);
                settopbottomdoor(true, mainbottomdoor);
                settopbottomdoor(true, mainpassworddoor);
                settopbottomdoor(true, mainupdoor);
                settopbottomdoor(false, mainrightupdoor);
                setdoor(false, mainrightrightdoor);
                break;
            case 4: // mainbottomroom
                setmainroom(false);
                setmainbottomroom(true);
                /* todo - ����� �� ���� - main ���� �Ⱥ��̰� ���ֱ�*/
                setdoor(false, traindoor);
                setdoor(false, mainrightdoor);
                settopbottomdoor(false, mainpassworddoor);
                settopbottomdoor(false, mainupdoor);
                break;
            case 5: // mainrightroom
                setmainroom(false);
                setmainrightroom(true);
                setrightroom(false);

                setdoor(false, traindoor);
                setdoor(true, mainrightdoor);
                setdoor(true, mainrightrightdoor);
                settopbottomdoor(false, mainbottomdoor);
                settopbottomdoor(false, mainpassworddoor);
                settopbottomdoor(false, mainupdoor);
                settopbottomdoor(true, mainrightupdoor);
                settopbottomdoor(false, rightupdoor);
                /*todo - ����� �� ���� - main ���� �Ⱥ��̰����ֱ�*/
                break;
            case 6: // mainrightuproom

                break;
            case 7: // rightroom
                setmainrightroom(false);
                setrightroom(true);

                setdoor(false, mainrightdoor);
                setdoor(true, mainrightrightdoor);
                settopbottomdoor(false, mainrightupdoor);
                settopbottomdoor(true, rightupdoor);
                break;
        }
    }
    // �� ����
    private void setdoor(bool active, GameObject door) // sidedoor ���̱�, �Ⱥ��̱�
    {
        if (active)
        {
            for (int i = 0; i < 4; i++)
            {
                door.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                door.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
    private void settopbottomdoor(bool active, GameObject door) // topdoor, bottomdoor ���̱�, �Ⱥ��̱�
    {
        if (active)
        {
            for (int i = 0; i < 3; i++)
            {
                door.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                door.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
    // �� ����
    private void setfirstroom(bool active) // 1
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
    private void settrainroom(bool active) // 2
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
    private void setmainroom(bool active) // 3
    {
        sprite = mainroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 3; i++)
            {
                mainroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 3; i++)
            {
                mainroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setmainbottomroom(bool active) // 4
    {
        sprite = mainbottomroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 5; i++)
            {
                mainbottomroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 5; i++)
            {
                mainbottomroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }



    private void setmainrightroom(bool active) // 5
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
    private void setrightroom(bool active)
    {
        sprite = rightroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 1; i++)
            {
                rightroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 1; i++)
            {
                rightroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}

