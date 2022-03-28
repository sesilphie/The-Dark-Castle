using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    public float AttackCooldown;
    float cooldownTimer = Mathf.Infinity;

    public Transform AttackPos;
    public LayerMask EnemyLayer;
    public float AttackRange;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > AttackCooldown && playerMovement.CanAttack())
            Attack();
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0f;
        //damage enemy
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, EnemyLayer);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            Debug.Log("Player Attack!");
            enemiesToDamage[i].GetComponent<Health>().Damage(1);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
