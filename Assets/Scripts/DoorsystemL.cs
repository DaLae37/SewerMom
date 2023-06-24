using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorsystemL : MonoBehaviour
{
    public bool isopen = false;
    private PlayerMove thePlayer;
    public GameObject lefttoOpen;
    public GameObject doorclose;
    public GameObject doorclose2;
    public GameObject block;
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
        if (collision.gameObject.name == "ToDoor" && thePlayer.IsKeydown && !isopen)
        {
            lefttoOpen.SetActive(true);
            doorclose.SetActive(false);
            doorclose2.SetActive(false);
            block.SetActive(false);
        }
    }
}
