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
    public GameObject passwordroom; // 11
    public GameObject passworduproom; // 12
    private SpriteRenderer sprite;
    public GameObject firstdoor;
    // mainroom�� ����� ���� //
    public GameObject traindoor;
    public GameObject mainpassworddoor;
    public GameObject mainbottomdoor;
    public GameObject mainupdoor;
    public GameObject mainrightdoor;
    //-----------------------//
    public GameObject mainupupdoor;
    public GameObject mainrightupdoor;
    public GameObject mainrightrightdoor;
    public GameObject rightupdoor;
    public GameObject passworddoor;
    // Start is called before the first frame update
    void Start()        //���ο� �� �߰��ɶ����� �߰����ֱ�. �ʱ⿡�� ���� ��Ȱ
    {
        setfirstroom(false); // 1
        settrainroom(false); // 2
        setmainroom(false); // 3
        setmainbottomroom(false); // 4
        setmainrightroom(false); // 5
        setmainrightuproom(false); // 6
        setrightroom(false); // 7
        setrightuproom(false);// 8
        setmainuproom(false); // 9
        setmainupuproom(false); // 10
        setpasswordroom(false); // 11
        setpassworduproom(false); // 12
        // door ���� 11��.
        setdoor(false, firstdoor);
        setdoor(false, traindoor);
        setdoor(false, mainrightdoor);
        setdoor(false, mainrightrightdoor);
        settopbottomdoor(false, mainbottomdoor);
        settopbottomdoor(false, mainpassworddoor);
        settopbottomdoor(false, mainupdoor);
        settopbottomdoor (false, mainupupdoor);
        settopbottomdoor(false, mainrightupdoor);
        settopbottomdoor(false, rightupdoor);
        settopbottomdoor(false, passworddoor);
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
                setmainuproom(false);
                setpasswordroom(false);
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
                settopbottomdoor(false, passworddoor);
                settopbottomdoor(false, mainupupdoor);
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
                setmainrightuproom(false);
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
                setmainrightroom(false);
                setmainrightuproom(true);

                setdoor(false, mainrightdoor);
                setdoor(false, mainrightrightdoor);
                
                break;
            case 7: // rightroom
                setmainrightroom(false);
                setrightroom(true);
                setrightuproom(false);

                setdoor(false, mainrightdoor);
                setdoor(true, mainrightrightdoor);
                settopbottomdoor(false, mainrightupdoor);
                settopbottomdoor(true, rightupdoor);
                break;
            case 8: // rightuproom
                setrightroom(false);
                setrightuproom(true);
                settopbottomdoor(true, rightupdoor);
                setdoor(false, mainrightrightdoor);
                break;
            case 9: // mainuproom
                setmainroom(false);
                setmainuproom(true);
                setmainupuproom(false);

                setdoor(false, traindoor);
                setdoor(false, mainrightdoor);
                settopbottomdoor(false, mainbottomdoor);
                settopbottomdoor(true, mainupdoor);
                settopbottomdoor(true, mainupupdoor);
                settopbottomdoor(false, mainpassworddoor);
                break;
            case 10: // mainupuproom
                setmainuproom(false);
                setmainupuproom(true);

                settopbottomdoor(false, mainupdoor);
                break;
            case 11: // passwordroom
                setmainroom(false);
                setpasswordroom(true);
                setpassworduproom(false);

                setdoor(false, traindoor);
                setdoor(false, mainrightdoor);
                settopbottomdoor(false, mainbottomdoor);
                settopbottomdoor(false, mainupdoor);
                settopbottomdoor(true, mainpassworddoor);
                settopbottomdoor(true, passworddoor);
                break;
            case 12: // passworduproom
                setpasswordroom(false);
                setpassworduproom(true);
                
                settopbottomdoor(false, mainpassworddoor);
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
            for (int i = 0; i < 2; i++)
            {
                firstroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 2; i++)
            {
                firstroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void settrainroom(bool active) // 2
    {
        sprite = trainroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            
            sprite.enabled = true;
            for (int i = 0; i < 3; i++)
            {
                trainroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 3; i++)
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
            for (int i = 0; i < 6; i++)
            {
                mainbottomroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 6; i++)
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
            for (int i = 0; i < 10; i++)
            {
                mainrightroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 10; i++)
            {
                mainrightroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setmainrightuproom(bool active) // 6
    {
        sprite = mainrightuproom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 2; i++)
            {
                mainrightuproom.transform.GetChild(i).gameObject.SetActive(true);
            }

        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 2; i++)
            {
                mainrightuproom.transform.GetChild(i).gameObject.SetActive(false);
            }

        }
    }
    private void setrightroom(bool active) // 7
    {
        sprite = rightroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 6; i++)
            {
                rightroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 6; i++)
            {
                rightroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setrightuproom(bool active) // 8
    {
        sprite = rightuproom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            rightuproom.transform.GetChild(0).gameObject.SetActive(true);
            rightuproom.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            sprite.enabled = false;
            rightuproom.transform.GetChild(0).gameObject.SetActive(false);
            rightuproom.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void setmainuproom(bool active) // 9
    {
        sprite = mainuproom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 6; i++)
            {
                mainuproom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 6; i++)
            {
                mainuproom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setmainupuproom(bool active) // 10
    {
        sprite = mainupuproom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 3; i++)
            {
                mainupuproom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 3; i++)
            {
                mainupuproom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setpasswordroom(bool active) // 11
    {
        sprite = passwordroom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            for (int i = 0; i < 3; i++)
            {
                passwordroom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            for (int i = 0; i < 3; i++)
            {
                passwordroom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setpassworduproom(bool active) // 12
    {
        sprite = passworduproom.GetComponent<SpriteRenderer>();
        if (active)
        {
            sprite.enabled = true;
            passworduproom.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            for (int i = 1; i < 2; i++)
            {
                passworduproom.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            sprite.enabled = false;
            passworduproom.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            for (int i = 1; i < 2; i++)
            {
                passworduproom.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
   
}

