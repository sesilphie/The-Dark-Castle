using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool hit;
    private float direction;

    private BoxCollider2D boxCollider;
    private Animator anim;
    
    private void Awake()
    {
        anim=GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();
    }
    

    // Update is called once per frame
    private void Update()
    {
        if(hit)return;
        float moveSpeed = speed *Time.deltaTime*direction;
        transform.Translate(moveSpeed,0,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit =true;
        boxCollider.enabled=false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction=_direction;
        gameObject.SetActive(true);
        hit=false;
        boxCollider.enabled=true;

        float localScaleX=transform.localScale.x;
        if(Mathf.Sign(localScaleX)!=_direction)
            localScaleX=-localScaleX;

        transform.localScale=new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);

    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
