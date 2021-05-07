using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;

    private Rigidbody2D skaterRB;
    private Animator animator;
    private MoveState moveState;

    void Start()
    {
        skaterRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveState = MoveState.Idle;
    }
    private void FixedUpdate()
    {
        UpdateHorizontalMove();
        PlayAnimation();
        DetectStop();
    }
    private void Update()
    {
        UpdateJumpMove();
    }
    void UpdateHorizontalMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveState = MoveState.RideRight;
            if (skaterRB.velocity.x < maxSpeed)
            {
                skaterRB.AddForce(new Vector2(moveForce, 0f));
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveState = MoveState.RideLeft;
            if (skaterRB.velocity.x > -maxSpeed)
            {
                skaterRB.AddForce(new Vector2(-moveForce, 0f));
            }
        }
    }
    void UpdateJumpMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveState = MoveState.Jump;
            skaterRB.AddForce(new Vector2(0f, jumpForce));
        }
    }
    void PlayAnimation()
    {
        if (moveState == MoveState.Idle)
        {
            animator.Play("Idle");
        }
        else if (moveState == MoveState.RideRight)
        {
            animator.Play("RideRight");
        }
        else if (moveState == MoveState.RideLeft)
        {
            animator.Play("RideLeft");
        }
        else if (moveState == MoveState.Jump)
        {
            animator.Play("Jump");
        }
    }
    void DetectStop()
    {
        if ((!Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A)) && (moveState != MoveState.Jump))
        {
            moveState = MoveState.Idle;
        }
    }

    private enum MoveState
    {
        Idle,
        RideRight,
        RideLeft, 
        Jump
    }
}
