using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newspaper : MonoBehaviour
{
    private PlayerMove thePlayer;
    private bool triggerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOn && thePlayer.IsKeydown) //신문지랑 상호작용.
        {
            TextLoader.instance.SetText("newspaper");
            SoundManager.instance.PlayEffect(13);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
        }
    }
}
