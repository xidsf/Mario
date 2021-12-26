using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask GroundLayer;
    Rigidbody2D rigid2D;
    BoxCollider2D box2D;
    Vector2 playerBottom;

    [SerializeField]
    private float jumpForce = 5.0f;
    public bool isAir = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate()
    {
        if(rigid2D.velocity.y >= 10)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 10);
        }
    }

    public void doJump()
    {
        rigid2D.velocity += Vector2.up * jumpForce;
    }

    public void MoveX(float speed)
    {
        rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);
    }

    public bool isJump()
    {
        RaycastHit2D hit;
        Bounds bounds = box2D.bounds;
        

        for (int i = 0; i < 3; i++)
        {
            playerBottom = new Vector2(bounds.center.x, bounds.min.y);
            playerBottom += Vector2.right * -0.4f;
            playerBottom += Vector2.right * i * 0.4f;

            hit = Physics2D.Raycast(playerBottom, Vector2.down, 0.05f, GroundLayer);
            Debug.DrawLine(playerBottom, playerBottom + Vector2.down * 0.05f, Color.blue, 1);
            if(hit)
            {
                isAir = false;
                return true;
            }
        }
        isAir = true;
        return false;
    }
    
}
