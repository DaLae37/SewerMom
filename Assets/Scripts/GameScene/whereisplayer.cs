using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whereisplayer : MonoBehaviour
{
    private MapController map;
    public int currentmap = 0; // �ʸ��� ����������� 
    // Start is called before the first frame update
    void Start()
    {
        map = FindObjectOfType<MapController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "formap") // ���� �� ī�����ϱ�
        {
            map.mapindex = currentmap;
        }
    }

}