using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject skater;
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;
    [SerializeField] private float rechargeTime;
    private float timeBetweenShots;

    private Animator animator;
    private Rigidbody2D enemyRB;
    private const string attack = "Attack";

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (timeBetweenShots <= 0)
        {
            float distFromPlayer = Mathf.Abs(transform.position.x - skater.transform.position.x);
            if (distFromPlayer < attackDistance)
            {
                Attack();
                timeBetweenShots = rechargeTime;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    private void Attack()
    {
        skater.GetComponent<SkaterHealth>().TakeDamage(damage);
        enemyRB.velocity = new Vector2(0f, enemyRB.velocity.y);
        animator.Play(attack);
    }

    public void SetSkater(GameObject skateBoarder)
    {
        skater = skateBoarder;
    }

   /* public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }*/


    public float GetAttackDistance() { return attackDistance; }
}
