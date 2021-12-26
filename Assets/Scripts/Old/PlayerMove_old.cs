/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }
    private void Update()
    {
        updateMove();
    }
    private void updateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.Moveto(x);
    }
}
*/