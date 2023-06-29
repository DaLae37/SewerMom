using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutorialPlayer : MonoBehaviour
{
    private PlayerMove player;
    public TutorialSceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        player.speed = (sceneManager.isTextRender) ? 0 : 5;
        if(sceneManager.tutorialPhase == 4 && player.useitem)
        {
            sceneManager.S.gameObject.SetActive(false);
            sceneManager.UIchocolate.SetActive(false);
            sceneManager.block.SetActive(false);

            sceneManager.textTimer = 0f;
            sceneManager.isTextRender = true;
            sceneManager.loader.SetText("TutorialItemEat");

            sceneManager.tutorialPhase++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "1" && sceneManager.tutorialPhase == 1)
        {
            sceneManager.tutorialPhase++;
            sceneManager.left.gameObject.SetActive(false);
            sceneManager.right.gameObject.SetActive(false);

            sceneManager.up.gameObject.SetActive(true);
            sceneManager.down.gameObject.SetActive(true);

            sceneManager.buttonTimer = 0f;
            sceneManager.buttonIndex = 0;

            sceneManager.textTimer = 0f;
            sceneManager.isTextRender = true;
            sceneManager.loader.SetText("TutorialUpDown");
        }
        if (collision.gameObject.name == "2" && sceneManager.tutorialPhase == 2)
        {
            sceneManager.tutorialPhase++;
            sceneManager.up.gameObject.SetActive(false);
            sceneManager.down.gameObject.SetActive(false);

            sceneManager.inventory.SetActive(true);
            sceneManager.arrow.SetActive(true);
            sceneManager.A.gameObject.SetActive(true);

            sceneManager.buttonTimer = 0f;
            sceneManager.buttonIndex = 0;

            sceneManager.textTimer = 0f;
            sceneManager.isTextRender = true;
            sceneManager.loader.SetText("TutorialItemGet");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "portal" && sceneManager.tutorialPhase == 5)
        {
            transform.position = new Vector3(102, -3.5f, 0);
            sceneManager.tutorialPhase++;
        }
        if (collision.collider.name == "chocolate" && player.IsKeydown && sceneManager.tutorialPhase == 3)
        {
            sceneManager.tutorialPhase++;

            sceneManager.A.gameObject.SetActive(false);
            sceneManager.chocolate.SetActive(false);
            sceneManager.arrow.SetActive(false);

            sceneManager.S.gameObject.SetActive(true);
            sceneManager.UIchocolate.SetActive(true);
            player.haveitem = true;

            sceneManager.buttonTimer = 0f;
            sceneManager.buttonIndex = 0;

            sceneManager.textTimer = 0f;
            sceneManager.isTextRender = true;
            sceneManager.loader.SetText("TutorialItemUse");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "chocolate" && player.IsKeydown && sceneManager.tutorialPhase == 3)
        {
            sceneManager.tutorialPhase++;

            sceneManager.A.gameObject.SetActive(false);
            sceneManager.chocolate.SetActive(false);
            sceneManager.arrow.SetActive(false);

            sceneManager.S.gameObject.SetActive(true);
            sceneManager.UIchocolate.SetActive(true);
            player.haveitem = true;

            sceneManager.buttonTimer = 0f;
            sceneManager.buttonIndex = 0;

            sceneManager.textTimer = 0f;
            sceneManager.isTextRender = true;
            sceneManager.loader.SetText("TutorialItemUse");
        }
    }
}
