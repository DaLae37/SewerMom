using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("7")]
    public bool activeOnce1 = false;

    [Header("8")]
    public bool activeOnce2 = false;

    [Header("9")]
    public bool setRespawn3 = false;
    public GameObject underBlock;
    public GameObject open;
    public GameObject close;
    public GameObject cheese;
    public GameObject cheeseUI;
    // Start is called before the first frame update
    void Start()
    {
        beforeMap = 0;
        afterMap = 0;
        spawnMonster = false;

        storyPhase = PlayerPrefs.GetInt("Story");
        Respawn(PlayerPrefs.GetInt("Respawn"));
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
                underBlock.SetActive(false);
                open.SetActive(true);
                close.SetActive(false);
                cheese.SetActive(false);
                cheeseUI.SetActive(true);
                player.GetComponent<PlayerMove>().itemname = "cheese";
                player.GetComponent<PlayerMove>().haveitem = true;
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
                }
                if (controller.mapindex != 3)
                {
                    storyPhase += 1;
                    hideTimer = 0f;
                    friendlyMouse.SetActive(false);
                }
                break;
            case 5:
                if (hideTimer > 1f)
                {

                }
                if (controller.mapindex == 3)
                {
                    monster.currentMap = controller.mapindex;
                    monster.transform.position = new Vector2(player.transform.position.x - 1, player.transform.position.y + 2.9f);
                }
                if (player.GetComponent<PlayerMove>().inhide)
                {
                    monster.gameObject.SetActive(false);
                    storyPhase += 1;
                }
                break;
            case 6:
                if (passwordOn)
                {
                    Camera.main.GetComponent<CameraManager>().isTargeting = false;
                    Camera.main.transform.position = new Vector3(-500, 0, -10);
                    if (inputPassword == "1253")
                    {
                        passwordClear = true;
                        passwordOn = false;
                    }
                    if (player.GetComponent<PlayerMove>().IsKeydown)
                    {
                        player.GetComponent<PlayerMove>().IsKeydown = false;
                        passwordOn = false;
                    }
                }
                else
                {
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
                if (player.GetComponent<PlayerMove>().inhide)
                {
                    monster.gameObject.SetActive(false);
                    storyPhase += 1;
                    hideTimer = 0f;
                }
                break;
            case 8:
                if(!activeOnce2 && hideTimer > 2f)
                {
                    activeOnce2 = true;
                    TextLoader.instance.SetText("SewerMomSay");
                    hideTimer = 0f;
                }
                else if(activeOnce2)
                {
                    if (hideTimer > 2f)
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
