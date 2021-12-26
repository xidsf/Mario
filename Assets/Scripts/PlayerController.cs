using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement2D movement2D;
    Animator anim;

    [SerializeField]
    private bool jumpable = false;
    [SerializeField]
    private float speed = 3.0f;

    public bool isDie = false;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        jumpable = movement2D.isJump();

        if(Input.GetKeyDown(KeyCode.Space) && jumpable)
        {
            movement2D.doJump();
        }

        if (movement2D.isAir)
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }

        float x = Input.GetAxisRaw("Horizontal");
        if(x != 0)
        {
            anim.SetBool("isStanding", false);
            anim.SetFloat("moveDirection", x);
        }
        else
        {
            anim.SetBool("isStanding", true);
        }
        movement2D.MoveX(x * speed);
    }

    private void onDie()
    {
        if(transform.position.y <= -7)
        {
            isDie = true;
        }
    }

}
