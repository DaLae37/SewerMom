using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    int endingResult; //0 : clear, 1 : catch by mom, 2 : catch by mouse, 3 : dump by train
    // Start is called before the first frame update
    void Start()
    {
        endingResult = PlayerPrefs.GetInt("EndingReason");
        if(endingResult == 0)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if(endingResult == 0)
            {
                LoadingScene();
            }
            else
            {
                GameScene();
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
