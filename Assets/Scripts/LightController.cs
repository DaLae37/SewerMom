using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightController : MonoBehaviour
{
    private PlayerMove Player; // 플레이어가 바라보고 있는 방향
    private Vector2 vector;
    private Quaternion rotation; // 회전(각도)을 담당하는 Vector4 x y z w
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
        vector.Set(Player.animator.GetFloat("DirX"), Player.animator.GetFloat("DirY"));
        if (vector.x == 1f)
        {
            
            rotation = Quaternion.Euler(0, 0, -90);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(0f, 0.75f, 0f);

        }
        else if (vector.x == -1f)
        {
            rotation = Quaternion.Euler(0, 0, 90);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(0f, 0.75f, 0f);
        }
        else if (vector.y == 1f)
        {
            rotation = Quaternion.Euler(0, 0, 0);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(-0.5f, 0.75f, 0f);
        }
        else if (vector.y == -1f)
        {
            rotation = Quaternion.Euler(0, 0, 180);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(0.5f, 0.75f, 0f);
        }
        
    }
}
