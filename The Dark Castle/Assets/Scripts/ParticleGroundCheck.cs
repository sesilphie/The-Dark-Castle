using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGroundCheck : MonoBehaviour
{
    public GameObject DustParticle;
    bool coroutineAllowed, grounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            grounded = true;
            coroutineAllowed = true;
            Instantiate(DustParticle, transform.position, DustParticle.transform.rotation);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            grounded = false;
            coroutineAllowed = false;
        }
    }
    private void Update()
    {
        if (grounded && PlayerMovement.rb.velocity.x != 0 && coroutineAllowed)
        {
            StartCoroutine("RunDustParticle");
            coroutineAllowed = false;
        }
        if (PlayerMovement.rb.velocity.x == 0 || !grounded)
        {
            StopCoroutine("RunDustParticle");
            coroutineAllowed = true;
        }
    }
    IEnumerator RunDustParticle()
    {
        while (grounded)
        {
            Instantiate(DustParticle, transform.position, DustParticle.transform.rotation);
            yield return new WaitForSeconds(0.25f);
        }
    }

}
