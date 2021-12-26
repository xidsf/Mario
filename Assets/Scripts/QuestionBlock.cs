using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [SerializeField]
    private LayerMask PlayerLayer;
    [SerializeField]
    AudioClip clip;
    AudioSource audioSource;
    BoxCollider2D box2D;
    Vector2 playerBottom;

    private void Awake()
    {
        box2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D hit;
        Bounds bounds = this.box2D.bounds;
        for (int i = 0; i < 3; i++)
        {
            playerBottom = new Vector2(bounds.center.x, bounds.min.y);
            playerBottom += Vector2.right * -0.45f;
            playerBottom += Vector2.right * i * 0.45f;

            hit = Physics2D.Raycast(playerBottom, Vector2.down, 0.02f, PlayerLayer);
            Debug.DrawLine(playerBottom, playerBottom + Vector2.down * 0.02f, Color.blue, 1);
            if (hit)
            {
                PlayCoinSound(clip);
                return;
            }
        }
    }
    
    public void PlayCoinSound(AudioClip Clip)
    {
        audioSource.PlayOneShot(Clip);
    }
}
