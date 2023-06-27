using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene 매니저 라이브러리 추가


public class ChangeMap : MonoBehaviour
{
    public string changeMapName; // 이동할 맵이름
    public Transform target; // 이동할 타겟(스타트 포인트) 설정

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

    // 박스 콜라이더에 닿는 순간 이벤트 발생
    
}
