using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform skater;
    [SerializeField] private float speed;
    [SerializeField] private float chasingDistance;

    private Rigidbody2D enemyRB;
    private Animator animator;
    private DirectionState directionState;

    private const string stay = "Stay";
    private const string walk = "Walk";

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        directionState = DirectionState.Right;
    }

    private void FixedUpdate()
    {
        float distFromPlayer = Mathf.Abs(transform.position.x - skater.position.x);
        if (distFromPlayer < chasingDistance && distFromPlayer > GetComponent<EnemyAttack>().GetAttackDistance())
        {
            StartChasing();
        }
        else
        {
            StopChasing();
        }
    }
    
    private void StartChasing()
    {
        if (skater.position.x < transform.position.x)
        {
            if (directionState ==  DirectionState.Right)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                directionState = DirectionState.Left;
            }
            enemyRB.velocity = new Vector2(-speed * Time.deltaTime, enemyRB.velocity.y);
            animator.Play(walk);
        }
        else
        {
            if (directionState == DirectionState.Left)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                directionState = DirectionState.Right;
            }
            enemyRB.velocity = new Vector2(speed * Time.deltaTime, enemyRB.velocity.y);
            animator.Play(walk);
        }
    }

    public void SetSkater(Transform skateBoarder)
    {
        skater = skateBoarder;
    }

    private void StopChasing()
    {
        enemyRB.velocity = new Vector2(0f, enemyRB.velocity.y);
    }

    private enum DirectionState
    {
        Right,
        Left
    }
}
