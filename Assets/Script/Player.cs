using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("대시 정보")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;

    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer;

    [Header("공격 정보")]
    [SerializeField] private float comboTime = 0.3f;
    private float comboTimeCounter;
    private bool isAttacking;
    private int comboCounter;

    private float xInput;

    protected override void Start()
    {
        base.Start();
    }
    
    protected override void Update()
    {   
        base.Update();

        CheckInput();
        Movement();


        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeCounter -= Time.deltaTime;

        FlipController();
        AnimatorControllers();

    }

    public void AttackOver()
    {
        isAttacking = false;

        comboCounter++;
        
        if (comboCounter > 2)
        {
            comboCounter = 0;
        }

    }

    private void CheckInput()
    {
        

        xInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }

    }   

    private void StartAttackEvent()
    {
        // 땅에서만 공격 가능하게
        if (!isGrounded) return;

        // 제 시간안에 못 치면 콤보 초기화
        if (comboTimeCounter < 0)
        {
            comboCounter = 0;
        }

        isAttacking = true;
        comboTimeCounter = comboTime;
    }
    
    private void DashAbility()
    {
        if(dashCooldownTimer < 0 && !isAttacking)
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }

    private void Movement()
    {   
        if (isAttacking)
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
        else if (dashTime > 0) // 대시
        {
            rb.linearVelocity = new Vector2(facingDir * dashSpeed,0);
        }
        else // 그냥 이동
        {
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        }

    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }


    //Alt + 화살표키
    private void AnimatorControllers()
    {
        bool isMoving = rb.linearVelocity.x != 0;
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDashing", dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }


    private void FlipController()
    {
        if(rb.linearVelocityX > 0 && !facingRight)
        {
            Flip();
        }
        else if(rb.linearVelocityX <0 &&facingRight)
        {
            Flip();
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }


}