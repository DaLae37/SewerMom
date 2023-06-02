using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene �Ŵ��� ���̺귯�� �߰�


public class ChangeMap : MonoBehaviour
{
    public string changeMapName; // �̵��� ���̸�
    public Transform target; // �̵��� Ÿ�� ����

    private PlayerMove thePlayer;
    private CameraManager theCamera;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        theCamera = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player") 
        {
            SceneManager.LoadScene(changeMapName);
        }
    }
}
