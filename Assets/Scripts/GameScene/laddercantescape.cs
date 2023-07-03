using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laddercantescape : MonoBehaviour
{
    private ladder ladderscript; 
    // Start is called before the first frame update
    void Start()
    {
        ladderscript = FindObjectOfType<ladder>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor" && !ladderscript.ismomhere)
        {
            TextLoader.instance.SetText("LadderFirst");
        }
    }
}
