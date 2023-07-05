using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    public int endingResult; //0 : clear, 1 : catch by mom, 2 : catch by mouse, 3 : dump by train
    // Start is called before the first frame update

    public GameObject clear;
    public GameObject gameOver;
    public GameObject monster;
    public float timer;
    public int index = 0;
    public GameObject[] arrow; 
    void Start()
    {
        timer = 0;
        endingResult = PlayerPrefs.GetInt("EndingReason");
        if(endingResult == 0)
        {
            clear.SetActive(true);
            PlayerPrefs.DeleteAll();
        }
        else
        {
            gameOver.SetActive(true);
            if (endingResult == 1)
            {
                monster.SetActive(true);
            }
            else
            {
                monster.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(endingResult == 0)
        {
            if(Input.GetKeyDown(KeyCode.Return)){
                LoadingScene();
            }
        }
        else
        {
            if(endingResult == 1 && timer < 2f) {
                
            }
            else
            {
                if(endingResult == 1 && timer >= 2f)
                {
                    monster.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    index -= 1;
                    if (index < 0)
                    {
                        index = 1;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    index += 1;
                    if (index >= 2)
                    {
                        index = 0;
                    }

                }
                for(int i=0; i<arrow.Length; i++)
                {
                    if (i == index)
                    {
                        arrow[i].SetActive(true);
                    }
                    else
                    {
                        arrow[i].SetActive(false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    switch(index)
                    {
                        case 0:
                            GameScene();
                            break;
                        case 1:
                            LoadingScene();
                            break;
                    }
                }
            }
        }
    }

    public void LoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
