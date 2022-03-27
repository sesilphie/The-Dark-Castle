using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideWays : MonoBehaviour
{
    public float Damage;
    public float MoveDistance;
    public float speed;
    bool moveLeft;
    float batasKiri;
    float batasKanan;

    private void Awake()
    {
        batasKiri = transform.position.x - MoveDistance;
        batasKanan = transform.position.x + MoveDistance;
    }
    private void Update()
    {
        //gerakan musuh
        if (moveLeft)
        {
            if (transform.position.x > batasKiri)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                moveLeft = false;
        }
        else
        {
            if (transform.position.x < batasKanan)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                moveLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().Damage(Damage);
        }
    }
}
