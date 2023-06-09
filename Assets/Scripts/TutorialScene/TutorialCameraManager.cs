using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialCameraManager : MonoBehaviour
{

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 대상이 있는지 체크
        if (target.gameObject != null)
        {
            // this는 카메라를 의미 (z값은 카메라 값 그대로 유지)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);


            // vectorA -> B까지 T의 속도로 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if(target.GetComponent<TutorialPlayer>().sceneManager.tutorialPhase < 6)
            {
                Vector3 position = new Vector3(Mathf.Clamp(transform.position.x, 0f, 38.9f), Mathf.Clamp(transform.position.y + 0.5f, -2.4f, 0.4f), transform.position.z);
                transform.position = position;
            }
        }
    }
}
