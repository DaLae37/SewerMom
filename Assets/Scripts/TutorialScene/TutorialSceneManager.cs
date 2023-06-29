using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneManager : MonoBehaviour
{
    public int tutorialPhase;

    public TextLoader loader;
    public bool isTextRender;

    private Color []buttonPressed = { new Color(1, 1, 1, 1), new Color(0.8f, 0.8f, 0.8f, 1) };
    public int buttonIndex = 0;
    [Header("0")]
    public GameObject stop;

    [Header("1")]
    public Image left;
    public Image right;

    [Header("2")]
    public Image up;
    public Image down;

    [Header("3")]
    public Image A;
    public GameObject inventory;
    public GameObject chocolate;
    public GameObject arrow;

    [Header("3")]
    public Image S;
    public GameObject UIchocolate;
    public GameObject block;

    public float buttonTimer = 0;
    public float textTimer = 0;
    public float arrowTimer = 0;

    public float maxTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        tutorialPhase = 0;
        isTextRender = false;
    }

    // Update is called once per frame
    void Update()
    {
        buttonTimer += Time.deltaTime;
        textTimer += Time.deltaTime;
        if (buttonTimer > maxTimer)
        {
            buttonTimer = 0f;
            buttonIndex = (buttonIndex + 1) % 2;
        }
        if (isTextRender && textTimer > maxTimer)
        {
            isTextRender = false;
        }

        switch (tutorialPhase)
        {
            case 0:
                if(buttonTimer > 0.7f && buttonIndex == 1)
                {
                    buttonTimer = 0f;
                    buttonIndex = 0;
                    left.gameObject.SetActive(true);
                    right.gameObject.SetActive(true);

                    stop.SetActive(false);

                    textTimer = 0f;
                    isTextRender = true;
                    loader.SetText("TutorialLeftRight");
                    
                    tutorialPhase++;
                }
                break;
            case 1: // 좌 우 움직임
                left.color = buttonPressed[buttonIndex];
                right.color = buttonPressed[buttonIndex];
                break;
            case 2: // 상 하 움직임
                up.color = buttonPressed[buttonIndex];
                down.color = buttonPressed[buttonIndex];
                break;
            case 3: // 아이템 획득
                arrowTimer += Time.deltaTime;
                if(arrowTimer > maxTimer * 2)
                {
                    arrowTimer = 0f;
                    arrow.SetActive(!arrow.activeSelf);
                }
                break;
            case 4: // 아이템 취식

                break;
            case 5: // 입장
                break;
            default:
                break;
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {

        }
    }

    public void GameScene()
    {
        PlayerPrefs.SetInt("tutorial", 1);
        SceneManager.LoadScene("GameScene");
    }
}
