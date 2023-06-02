using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour // 나중에 다른 씬으로 로드하는 거면 필요함. 기존 ChangeMap에서 씬로드를 하고 여기서 포지션을 배정함.
{
    public string startPoint; // 이동되어온 맵이름을 체크하기 위한 변수
    private PlayerMove thePlayer; // 캐릭터 객체 가져오기 위한 변수
    private CameraManager theCamera; // 자연스러운 카메라 이동을 위해 가져온 카메라 변수



    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>(); // 카메라 변수에 카메라 객체를 할당
        thePlayer = FindObjectOfType<PlayerMove>(); // 캐릭터 변수에 현재 캐릭터 객체를 할당

        if(startPoint == thePlayer.currentMapName)
        {
            // 카메라 이동
            theCamera.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            // 캐릭터 이동
            thePlayer.transform.position = this.transform.position;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
