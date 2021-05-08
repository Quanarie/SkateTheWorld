using System.Collections;
using UnityEngine;

public class OnSkateMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;

    private Rigidbody2D skaterRB;
    private Animator animator;
    private DirectionState directionState;
    private MoveState moveState;

    private const float jumpAnimationLength = 1.283f;
    private const string RideRight = "RideRight";
    private const string RideLeft = "RideLeft";
    private const string JumpRight = "JumpRight";
    private const string JumpLeft = "JumpLeft";

    private void Start()
    {
        skaterRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        moveState = MoveState.Idle;
        directionState = DirectionState.Right;
    }

    private void FixedUpdate()
    {
        Ride();
    }

    private void Update()
    {
        Ollie();
    }

    private void Ride()
    {
        if (Input.GetKey(KeyCode.D))
        {
            directionState = DirectionState.Right;
            if (skaterRB.velocity.x < maxSpeed)
                skaterRB.AddForce(new Vector2(moveForce, 0f));

            if (moveState != MoveState.Jump)
            {
                moveState = MoveState.Ride;
                animator.Play(RideRight);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionState = DirectionState.Left;
            if (skaterRB.velocity.x > -maxSpeed)
                skaterRB.AddForce(new Vector2(-moveForce, 0f));

            if (moveState != MoveState.Jump)
            {
                moveState = MoveState.Ride;
                animator.Play(RideLeft);
            }
        }
    }

    private void Ollie()
    {
        if (Input.GetKeyDown(KeyCode.Space) && moveState != MoveState.Jump)
        {
            moveState = MoveState.Jump;
            skaterRB.AddForce(new Vector2(0f, jumpForce));

            if (directionState == DirectionState.Right)
            {
                animator.Play(JumpRight);
            }
            else if (directionState == DirectionState.Left)
            {
                animator.Play(JumpLeft);
            }

            StartCoroutine(EndJump());
        }
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(jumpAnimationLength);
        moveState = MoveState.Idle;
    }

    private enum DirectionState
    {
        Right,
        Left
    }
    private enum MoveState
    {
        Idle,
        Ride,
        Jump
    }
}