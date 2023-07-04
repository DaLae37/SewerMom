using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
    public Camera passwordCamera;
    public Text passwordText;
    public string [] password = new string[4];
    public int passwordIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetPassword();
    }

    // Update is called once per frame
    void Update()
    {
        SetPassword();
        if (Input.GetMouseButtonDown(0))
        {
            if (passwordIndex < 4)
            {
                Ray ray = passwordCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Number")
                    {
                        password[passwordIndex++] = hit.collider.gameObject.name;
                    }
                }
            }
            else
            {
                StoryManager.instance.inputPassword = passwordText.text;
                ResetPassword();
            }
        }
    }

    void SetPassword()
    {
        passwordText.text = password[0] + password[1] + password[2] + password[3];
    }

    public void ResetPassword()
    {
        passwordIndex = 0;
        password[0] = "0";
        password[1] = "0";
        password[2] = "0";
        password[3] = "0";
    }
}
