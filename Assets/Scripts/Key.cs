using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerMove thePlayer;
    public GameObject silverkey;
    public GameObject inventorykey;
    private bool havekey = false;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ToDoor" && thePlayer.IsKeydown)
        {
            silverkey.SetActive(false);
            inventorykey.SetActive(true);
            havekey = true;
            TextLoader.instance.SetText("GetKey");
        }
    }
}
