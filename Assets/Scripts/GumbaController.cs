using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbaController : MonoBehaviour
{
    Movement2D movement2D;
    Animator anim;
    BoxCollider2D Box2D;
    Rigidbody2D rigid2D;

    private Vector2 headPosition;
    private bool isUpPlayer;
    [SerializeField]
    private LayerMask PlayerLayer;

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    GameObject Player;


    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        anim = GetComponent<Animator>();
        Box2D = GetComponent<BoxCollider2D>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement2D.MoveX(-speed);
    }
    
    private void OnDie()
    {
        rigid2D.gravityScale = 0;
        speed = 0;
        Destroy(GetComponent<BoxCollider2D>());
        anim.SetBool("onDie", true);
        Destroy(gameObject, 1);
    }

    private void KillPlayer()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounds bounds = this.Box2D.bounds;
        RaycastHit2D hit;
        headPosition = new Vector2(bounds.center.x - 0.4f, bounds.max.y);
        
        for (int i = 0; i < 3; i++)
        {
            headPosition = headPosition + Vector2.right * 0.41f * i;
            hit = Physics2D.Raycast(headPosition, Vector2.up, 0.1f, PlayerLayer);
            Debug.DrawLine(headPosition, headPosition + Vector2.up * 0.1f, Color.blue, 1);
            if(hit)
            {
                OnDie();
            }
        }
    }
}
