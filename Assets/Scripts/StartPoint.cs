using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour // ���߿� �ٸ� ������ �ε��ϴ� �Ÿ� �ʿ���. ���� ChangeMap���� ���ε带 �ϰ� ���⼭ �������� ������.
{
    public string startPoint; // �̵��Ǿ�� ���̸��� üũ�ϱ� ���� ����
    private PlayerMove thePlayer; // ĳ���� ��ü �������� ���� ����
    private CameraManager theCamera; // �ڿ������� ī�޶� �̵��� ���� ������ ī�޶� ����



    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>(); // ī�޶� ������ ī�޶� ��ü�� �Ҵ�
        thePlayer = FindObjectOfType<PlayerMove>(); // ĳ���� ������ ���� ĳ���� ��ü�� �Ҵ�

        if(startPoint == thePlayer.currentMapName)
        {
            // ī�޶� �̵�
            theCamera.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            // ĳ���� �̵�
            thePlayer.transform.position = this.transform.position;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
