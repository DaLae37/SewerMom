using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    AudioSource audio;
    Vector3 originPos = new Vector3(0, 20, 0);
    bool shakeX;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = originPos;
        audio = GetComponent<AudioSource>();
        audio.loop = false;

        shakeX = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * ((shakeX) ? -0.25f : 0.25f), transform.position.y - Time.deltaTime * 5, transform.position.z);
        if(transform.position.x < -0.1f || transform.position.x > 0.1f)
        {
            shakeX = !shakeX;
        }
        if (transform.position.y < -50)
        {
            transform.position = originPos;
            audio.Stop();
            audio.Play();
        }
    }
}
