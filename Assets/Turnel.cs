using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnel : MonoBehaviour
{
    public bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && StoryManager.instance.storyPhase == 2)
        {
            once = true;
            TextLoader.instance.SetText("railroad");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            once = false;
        }
    }
}
