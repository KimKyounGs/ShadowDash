using UnityEngine;

public class Enemy_Skeleton : Entity
{
    [Header("이동 정보")]
    [SerializeField] private float moveSpeed;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (!isGrounded || isWallDetected)
            Flip();

        rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocity.y);
    }
}
