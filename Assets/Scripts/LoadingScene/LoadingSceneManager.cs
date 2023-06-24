using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingSceneManager : MonoBehaviour
{
    public SpriteRenderer logo;
    float timer = 0f;
    float maxTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            MainScene();
        }
        timer += Time.deltaTime;
        if (3 - (timer * 1.5f) <= 3)
        {
            logo.color = new Color(1, 1, 1, 0 + 1 / (3 - (timer * 1.5f)));
        }
        else
        {
            logo.color = new Color(1, 1, 1, 1);
        }
        if (timer > maxTimer)
        {
            MainScene();
        }
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
