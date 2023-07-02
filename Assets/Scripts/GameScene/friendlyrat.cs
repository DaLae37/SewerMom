using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyrat : MonoBehaviour
{
    public GameObject cantgo;
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
        if (triggerOn && thePlayer.IsKeydown) //��� ��ȣ�ۿ�
        {
            GetComponent<BoxCollider2D>().enabled = false;
            cantgo.SetActive(false);
            TextLoader.instance.SetText("friendlyrat");
            // todo �� ���������� �������� ������ ���߱�
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
