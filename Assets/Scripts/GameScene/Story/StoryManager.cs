using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    public int storyPhase;
    [Header("0")]
    public GameObject cantogo;

    [Header("1")]
    public GameObject flashLight;
    public GameObject friendlyMouse;

    [Header("2")]
    public GameObject train;
    // Start is called before the first frame update
    void Start()
    {
        storyPhase = PlayerPrefs.GetInt("Story");
        Respawn(PlayerPrefs.GetInt("Respawn"));
        instance = this;
    }

    public void Respawn(int phase)
    {
        switch (phase)
        {
            case 1:
                if (cantogo.activeSelf)
                {
                    cantogo.SetActive(false);
                }
                if (flashLight.activeSelf)
                {
                    flashLight.SetActive(false);
                }
                break;
        }
    }

    public void Death(int reason)
    {//0 : clear, 1 : catch by mom, 2 : catch by mouse, 3 : dump by train
        switch (reason)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:
                PlayerPrefs.SetInt("EndingReason", reason);
                SceneManager.LoadScene("EndingScene");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (storyPhase)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:
                if (!train.activeSelf)
                {
                    train.SetActive(true);
                }
                break;
        }
    }


}
