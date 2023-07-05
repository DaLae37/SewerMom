using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneManager : MonoBehaviour
{
    public GameObject[] cursor;
    public int cursorIndex;
    // Start is called before the first frame update
    void Start()
    {
        cursorIndex = 0;
        SoundManager.instance.PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            cursor[cursorIndex--].SetActive(false);
            cursorIndex = (cursorIndex < 0) ? 2 : cursorIndex;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            cursor[cursorIndex++].SetActive(false);
            cursorIndex %= 3;
        }
        cursor[cursorIndex].SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.instance.PlayEffect(0);
            switch (cursorIndex)
            {
                case 0:
                    GameScene();
                    break;
                case 1:
                    SettingScene();
                    break;
                case 2:
                    Application.Quit();
                    break;
                default:
                    break;
            }
        }
    }

    public void SettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void GameScene()
    {
        int tutorial = PlayerPrefs.GetInt("tutorial");
        if(tutorial == 0)
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
