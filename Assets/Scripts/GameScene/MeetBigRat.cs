using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetBigRat : MonoBehaviour
{
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
        if (collision.gameObject.name == "fordoor")
        {
            if(StoryManager.instance.player.GetComponent<PlayerMove>().hadCheese && StoryManager.instance.player.GetComponent<PlayerMove>().usebitecheese)
            {
                StoryManager.instance.Death(2);
            }
            else if(transform.parent.GetComponent<BigRatMove>().blockplayer)
            {
                TextLoader.instance.SetText("meetbigrat");
            }
        }
    }
}
