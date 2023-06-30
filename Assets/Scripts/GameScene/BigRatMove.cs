using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRatMove : MonoBehaviour
{
    // �ѤѤѤѤѤ��̵��ѤѤѤѤѤ� //
    public float speed; // �����̴� �ӵ� ����
    private Vector2 vector;
    // �ѤѤѤѤѤѾִϸ��̼ǤѤѤѤѤѤ� //
    public Animator animator;
    private MapController mapcontrol;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mapcontrol = FindObjectOfType<MapController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        vector = Vector2.zero;
        if (mapcontrol.mapindex == 8)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                if (vector.x != 0)
                {
                    vector.y = 0;
                }
                animator.SetFloat("DirY", vector.y);
                animator.SetBool("Walking", true);
                vector.Set(0, vector.y);
                GetComponent<Rigidbody2D>().velocity = vector * speed;
            }
            else
            {
                animator.SetBool("Walking", false);
                GetComponent<Rigidbody2D>().velocity = vector * speed;
            }
        }
    }
}
