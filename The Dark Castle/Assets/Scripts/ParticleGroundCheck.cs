using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGroundCheck : MonoBehaviour
{
    public GameObject DustParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Instantiate(DustParticle, transform.position, DustParticle.transform.rotation);
        }
    }
}
