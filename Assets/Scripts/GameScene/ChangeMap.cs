using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene �Ŵ��� ���̺귯�� �߰�


public class ChangeMap : MonoBehaviour
{
    public string changeMapName; // �̵��� ���̸�
    public Transform target; // �̵��� Ÿ��(��ŸƮ ����Ʈ) ����

    private PlayerMove thePlayer;
    private CameraManager theCamera;
    public GameObject inventorykey;
    
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

    // �ڽ� �ݶ��̴��� ��� ���� �̺�Ʈ �߻�
    
}
