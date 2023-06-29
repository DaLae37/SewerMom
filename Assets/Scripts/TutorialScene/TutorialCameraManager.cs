using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialCameraManager : MonoBehaviour
{

    public GameObject target; // ī�޶� ���� ���
    public float moveSpeed; // ī�޶� ���� �ӵ�
    private Vector3 targetPosition; // ����� ���� ��ġ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ����� �ִ��� üũ
        if (target.gameObject != null)
        {
            // this�� ī�޶� �ǹ� (z���� ī�޶� �� �״�� ����)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);


            // vectorA -> B���� T�� �ӵ��� �̵�
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            Vector3 position = new Vector3(Mathf.Clamp(transform.position.x, 0f, 38.9f), Mathf.Clamp(transform.position.y + 0.5f, -2.4f, 0.4f), transform.position.z);
            transform.position = position;
        }
    }
}
