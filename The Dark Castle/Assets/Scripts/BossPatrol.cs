using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    public Transform LeftBoundary;
    public Transform RightBoundary;

    [Header ("Boss Enemy")]
    public Transform enemyBoss;

    [Header ("Movement parameters")]
    public float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Idle Behaviour")]
    public float IdleDuration;
    private float idleTimer;
    
    [Header("Boss Enemy Animator")]
    public Animator anim;

    private void Awake()
    {
        initScale=enemyBoss.localScale;
    }

    private void Update()
    {
        if(movingLeft)
        {
            if(enemyBoss.position.x>=LeftBoundary.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(enemyBoss.position.x<=RightBoundary.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
        
    }
    private void DirectionChange()
    {
        anim.SetBool("moving",false);

        idleTimer+=Time.deltaTime;
        if(idleTimer>IdleDuration)
        {
            movingLeft =!movingLeft;
        }
        
    }
    
    private void MoveInDirection(int _direction)
    {
        idleTimer=0;
        anim.SetBool("moving",true);
        //enemy hadap ke direction
        enemyBoss.localScale=new Vector3(Mathf.Abs(initScale.x)*_direction, initScale.y,initScale.z );

        //jalan ke direction
        enemyBoss.position = new Vector3(enemyBoss.position.x +Time.deltaTime *_direction*speed, 
                        enemyBoss.position.y,enemyBoss.position.z);

    }
}
