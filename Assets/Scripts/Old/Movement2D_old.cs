/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ColliderCorner
{
    public Vector2 topLeft;
    public Vector2 bottomLeft;
    public Vector2 bottomRight;
}

public struct CollisionChecker
{
    public bool up;
    public bool down;
    public bool right;
    public bool left;

    public void Reset()
    {
        up = false;
        down = false;
        right = false;
        left = false;
    }
}

public class Movement2D : MonoBehaviour
{
    [Header("Raycast Collision")]
    [SerializeField]
    LayerMask collisionLayer; //광선과 충돌하는 충돌 레이어

    [Header("Raycast")]
    [SerializeField]
    private int horizontalRayCount = 4;
    [SerializeField]
    private int verticalRayCount = 4;

    private float horizontalRaySpacing;
    private float verticalRaySpacing;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 3.0f;
    private float gravity = -20f;
    [SerializeField]
    private float jumpForce = 10.0f;

    private Collider2D collider2D;
    private CollisionChecker collisionChecker;
    private ColliderCorner colliderCorner;

    private Vector3 velocity;
    private readonly float skinWidth = 0.015f;


    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        CalculateRaySpacing();
        UpdateColliderCorner();
        collisionChecker.Reset();

        if(collisionChecker.up || collisionChecker.down)
        {
            velocity.y = 0;
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            JumpTo();
        }

    }

    private void updateMovement()
    {
        velocity.y += gravity * Time.deltaTime;

        Vector3 currentVelocity = velocity * Time.deltaTime;

        if(currentVelocity.y != 0)
        {
            RaycastVertical(ref velocity);
        }
        if (currentVelocity.x != 0)
        {
            RaycastHorizontal(ref velocity);
        }

        transform.position += currentVelocity;
    }

    public void Moveto(float x)
    {
        velocity.x = x * moveSpeed;
    }

    private void JumpTo()
    {
        if(collisionChecker.down)
        {
            velocity.y = jumpForce;
        }
    }

    private void CalculateRaySpacing()
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    private void UpdateColliderCorner()
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(skinWidth * -2);

        colliderCorner.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        colliderCorner.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        colliderCorner.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    }



    private void RaycastVertical(ref Vector3 velocity)
    {
        float direction = Mathf.Sign(velocity.y); //상승중이면1 낙하중이면-1
        float distance = Mathf.Abs(velocity.y); //광선의 길이
        Vector2 RayPosition = Vector2.zero; //광선 발사 위치
        RaycastHit2D hit;

        for (int i = 0; i < verticalRayCount; i++)
        {
            RayPosition = (direction == 1) ? colliderCorner.topLeft : colliderCorner.bottomLeft;
            RayPosition += Vector2.right * (verticalRaySpacing * i + velocity.x);

            hit = Physics2D.Raycast(RayPosition, Vector2.up*direction, distance, collisionLayer);

            if(hit)
            {
                velocity.y = (hit.distance - skinWidth) * direction;
                distance = hit.distance;

                collisionChecker.down = (direction == -1);
                collisionChecker.up = (direction == 1);
            }
            Debug.DrawLine(RayPosition, RayPosition + Vector2.up * direction * distance, Color.blue);
        }
    }
    private void RaycastHorizontal(ref Vector3 velocity)
    {
        float direction = Mathf.Sign(velocity.x); //오른쪽이면1 왼쪽이면-1
        float distance = Mathf.Abs(velocity.x); //광선의 길이
        Vector2 RayPosition = Vector2.zero; //광선 발사 위치
        RaycastHit2D hit;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            RayPosition = (direction == 1) ? colliderCorner.bottomRight : colliderCorner.bottomLeft;
            RayPosition += Vector2.up * (horizontalRaySpacing * i);
            hit = Physics2D.Raycast(RayPosition, Vector2.right * direction, distance, collisionLayer);

            if (hit)
            {
                velocity.y = (hit.distance - skinWidth) * direction;
                distance = hit.distance;

                collisionChecker.left = (direction == -1);
                collisionChecker.right = (direction == 1);
            }
            Debug.DrawLine(RayPosition, RayPosition + Vector2.right * direction * distance, Color.blue);
        }
    }

}
*/