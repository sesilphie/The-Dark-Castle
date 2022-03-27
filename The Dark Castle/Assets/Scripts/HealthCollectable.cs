using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(health);
            gameObject.SetActive(false);
        }
    }
}
