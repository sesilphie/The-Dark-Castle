using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackCooldown;
    public float range;
    public float colliderDistance;
    public int damage;
    public BoxCollider2D boxCollider;
    public LayerMask PlayerLayer;
    private float cooldownTimer=Mathf.Infinity;

    public GameObject[] Fireballs;
    public Transform FirePoint;

    private Animator anim;
    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer+=Time.deltaTime;
        
        //serang saat player muncul
        if(PlayerInSight())
        {
            if (cooldownTimer>=attackCooldown)
            {
            //serang
                cooldownTimer=0;
                anim.SetTrigger("bossAttack");
                Fireballs[FindFireball()].transform.position=FirePoint.position;
                Fireballs[FindFireball()].GetComponent<BossFireball>().SetDirection(Mathf.Sign(transform.localScale.x));
            }

        }
        
    }
    

    private int FindFireball()
    {
        for(int i=0; i<Fireballs.Length; i++)
        {
            if(!Fireballs[i].activeInHierarchy)
            {
                return i;   
            }
        }
        return 0;
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+ transform.right*range *transform.localScale.x*colliderDistance, 
                    new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z),
                    0,Vector2.left,0,PlayerLayer);
        if(hit.collider!=null)
        {
            playerHealth=hit.transform.GetComponent<Health>();

        }
        return hit.collider!=null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+ transform.right*range *transform.localScale.x*colliderDistance,
         new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z));
    }
}
