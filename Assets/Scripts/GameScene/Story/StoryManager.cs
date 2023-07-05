using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    public int storyPhase;

    public GameObject player;

    public SewerMom monster;
    public bool spawnMonster;

    public MapController controller;
    public int beforeMap;
    public int afterMap;

    [Header("0")]
    public GameObject cantogo;

    [Header("1")]
    public bool setRespawn1 = false;
    public bool lightOn = false;
    public GameObject flashLight;
    public GameObject friendlyMouse;

    [Header("2")]
    public GameObject train;

    [Header("3")]
    public bool setRespawn2 = false;

    [Header("5")]
    public float hideTimer = 0;

    [Header("6")]
    public bool passwordClear = false;
    public bool passwordOn = false;
    public string inputPassword;
    public Light2D global;

    [Header("7")]
    public bool activeOnce1 = false;

    [Header("8")]
    public bool activeOnce2 = false;
    public bool feed41 = false;
    public bool feed42 = false;
    public bool feed6 = false;

    [Header("9")]
    public bool setRespawn3 = false;
    public GameObject underBlock1;
    public GameObject open1;
    public GameObject close1;
    public GameObject cheese;
    public GameObject cheeseUI;

    [Header("10")]
    public bool setRespawn4 = false;
    public BigRatMove rat;
    public GameObject keyUI;
    public GameObject key;
    public GameObject underBlock2;
    public GameObject door2;
    public GameObject open2;
    public GameObject close2;
    [Header("11")]
    public GameObject block11;

    [Header("12")]
    public bool activeOnce3 = false;

    [Header("13")]
    public escapedoor escapedoor;
    public bool activeOnce4 = false;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.StopBGM();
        beforeMap = 0;
        afterMap = 0;
        spawnMonster = false;

        storyPhase = PlayerPrefs.GetInt("Story");
        Respawn(2);
        instance = this;
    }

    public void Respawn(int phase)
    {
        switch (phase)
        {
            case 1:
                storyPhase = 2;
                lightOn = true;
                if (cantogo.activeSelf)
                {
                    cantogo.SetActive(false);
                }
                if (flashLight.activeSelf)
                {
                    flashLight.SetActive(false);
                }
                friendlyMouse.transform.position = new Vector3(11.5f, -0.1f, 0);
                friendlyMouse.GetComponent<friendlyrat>().walkOn = 5;
                controller.mapindex = 1;
                break;
            case 2:
                storyPhase = 3;
                lightOn = true;
                if (cantogo.activeSelf)
                {
                    cantogo.SetActive(false);
                }
                if (flashLight.activeSelf)
                {
                    flashLight.SetActive(false);
                }
                friendlyMouse.transform.position = new Vector3(11.5f, -0.1f, 0);
                friendlyMouse.GetComponent<friendlyrat>().walkOn = 5;
                player.transform.position = new Vector2(11.4f, -3.5f);
                controller.mapindex = 3;
                break;
            case 3:
                storyPhase = 9;
                lightOn = true;
                monster.walkOn = 4;
                if (cantogo.activeSelf)
                {
                    cantogo.SetActive(false);
                }
                if (flashLight.activeSelf)
                {
                    flashLight.SetActive(false);
                }
                friendlyMouse.SetActive(false);
                player.transform.position = new Vector2(18.75f, 4.5f);
                controller.mapindex = 11;
                underBlock1.SetActive(false);
                open1.SetActive(true);
                close1.SetActive(false);
                cheese.SetActive(false);
                cheeseUI.SetActive(true);
                player.GetComponent<PlayerMove>().itemname = "cheese";
                player.GetComponent<PlayerMove>().haveitem = true;
                player.GetComponent<PlayerMove>().hadCheese = true;
                break;
            case 4:
                storyPhase = 10;
                lightOn = true;
                monster.walkOn = 4;
                if (cantogo.activeSelf)
                {
                    cantogo.SetActive(false);
                }
                if (flashLight.activeSelf)
                {
                    flashLight.SetActive(false);
                }
                friendlyMouse.SetActive(false);
                player.transform.position = new Vector2(80, 4);
                cheese.SetActive(false);
                keyUI.SetActive(true);
                key.SetActive(false);
                open2.SetActive(true);
                close2.SetActive(false);
                underBlock2.SetActive(false);
                player.GetComponent<PlayerMove>().itemname = "goldkey";
                player.GetComponent<PlayerMove>().haveitem = true;
                rat.blockplayer = false;
                controller.mapindex = 8;
                break;
        }
    }

    public void Death(int reason)
    {//0 : clear, 1 : catch by mom, 2 : catch by mouse, 3 : dump by train
        PlayerPrefs.SetInt("EndingReason", reason);
        SceneManager.LoadScene("EndingScene");
        PlayerPrefs.GetInt("Story", storyPhase);
    }

    public void SpawnMonster()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hideTimer += Time.deltaTime;
        if (storyPhase >= 8)
        {
            if(controller.mapindex == 4 && (!feed41 || !feed42))
            {
                if (!SoundManager.instance.mouse.isPlaying)
                {
                    SoundManager.instance.MouseOn();
                }
            }
            else if(controller.mapindex == 6 && (!feed6))
            {
                if (!SoundManager.instance.mouse.isPlaying)
                {
                    SoundManager.instance.MouseOn();
                }
            }
            else
            {
                SoundManager.instance.MouseOff();
            }
        }
        if (!monster.gameObject.activeSelf)
        {
            monster.playerOn = false;
            SoundManager.instance.MomOff();
        }
        if (monster.playerOn)
        {
            if(!SoundManager.instance.bgm.isPlaying)
                SoundManager.instance.PlayBGM(2);

            if (storyPhase >= 8  && controller.mapindex == 4 && (!feed41 || !feed42))
            {
                if (player.GetComponent<PlayerMove>().inhide && hideTimer > 1f)
                {
                    SoundManager.instance.PlayEffect(12);
                    Death(3);
                }
            }
            else if (storyPhase >= 8 && controller.mapindex == 6 && (!feed6))
            {
                if (player.GetComponent<PlayerMove>().inhide && hideTimer > 1f)
                {
                    SoundManager.instance.PlayEffect(12);
                    Death(3);
                }
            }

            if (beforeMap == controller.mapindex)
            {
                monster.currentMap = controller.mapindex;
                monster.transform.position = new Vector2(player.transform.position.x - 1, player.transform.position.y + 2.9f);
            }
        }
        else
        {
            if (SoundManager.instance.bgm.isPlaying)
                SoundManager.instance.StopBGM();
        }
        switch (storyPhase)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:
                if (!setRespawn1)
                {
                    setRespawn1 = true;
                    PlayerPrefs.SetInt("Respawn", 1);
                }
                if (!train.activeSelf)
                {
                    train.SetActive(true);
                }
                break;
            case 3:
                if (!setRespawn2)
                {
                    setRespawn2 = true;
                    PlayerPrefs.SetInt("Respawn", 2);
                }
                break;
            case 4:
                if (!monster.gameObject.activeSelf)
                {
                    monster.gameObject.SetActive(true);
                    monster.playerOn = true;
                }
                if (controller.mapindex != 3)
                {
                    storyPhase += 1;
                    hideTimer = 0f;
                    friendlyMouse.SetActive(false);
                }
                break;
            case 5:
                if (player.GetComponent<PlayerMove>().inhide)
                {
                    monster.gameObject.SetActive(false);
                    monster.DirX = 0;
                    monster.DirY = 0;
                    storyPhase += 1;
                    monster.playerOn = false;
                }
                break;
            case 6:
                if (passwordOn)
                {
                    global.intensity = 1f;
                    Camera.main.GetComponent<CameraManager>().isTargeting = false;
                    Camera.main.transform.position = new Vector3(-500, 0, -10);
                    if (inputPassword == "1253")
                    {
                        passwordClear = true;
                        passwordOn = false;
                        TextLoader.instance.SetText("CorrectPassword");
                    }
                    if (player.GetComponent<PlayerMove>().IsKeydown)
                    {
                        player.GetComponent<PlayerMove>().IsKeydown = false;
                        passwordOn = false;
                    }
                }
                else
                {
                    global.intensity = 0f;
                    Camera.main.GetComponent<CameraManager>().isTargeting = true;
                }
                if(player.GetComponent<PlayerMove>().itemname == "cheese")
                {
                    storyPhase += 1;
                }
                break;
            case 7:
                if(controller.mapindex == 11 && !activeOnce1)
                {
                    activeOnce1 = true;
                    monster.gameObject.SetActive(true);
                    monster.transform.position = new Vector2(18.75f, 0);
                }
                if (monster.gameObject.activeSelf && player.GetComponent<PlayerMove>().inhide)
                {
                    monster.gameObject.SetActive(false);
                    storyPhase += 1;
                    hideTimer = 0f;
                }
                break;
            case 8:
                if(!activeOnce2 && hideTimer > 4f)
                {
                    activeOnce2 = true;
                    SoundManager.instance.PlayEffect(24);
                    TextLoader.instance.SetTextRed("SewerMomSay");
                    hideTimer = 0f;
                }
                else if(activeOnce2)
                {
                    if (hideTimer > 4f)
                    {
                        monster.gameObject.SetActive(false);
                        storyPhase += 1;
                    }
                }
                break;
            case 9:
                if (!setRespawn3)
                {
                    setRespawn3 = true;
                    PlayerPrefs.SetInt("Respawn", 3);
                }
                if(player.GetComponent<PlayerMove>().itemname == "goldkey")
                {
                    storyPhase += 1;
                }
                break;
            case 10:
                if (!setRespawn4)
                {
                    setRespawn4 = true;
                    PlayerPrefs.SetInt("Respawn", 4);
                }
                if (player.GetComponent<PlayerMove>().itemname == "lighter")
                {
                    storyPhase += 1;
                    block11.SetActive(true);
                }
                break;
            case 11:
                
                break;
            case 12:
                if (!activeOnce3 && player.GetComponent<PlayerMove>().itemname =="")
                {
                    monster.gameObject.SetActive(true);
                    monster.transform.position = new Vector2(30, -0.9f);
                    activeOnce3 = true;
                }
                break;
            case 13:
                if (!activeOnce4)
                {
                    escapedoor.canescape = true;
                }
                break;
        }
        if (afterMap != controller.mapindex)
        {
            hideTimer = 0f;
            beforeMap = afterMap;
            afterMap = controller.mapindex;
        }
    }


}
