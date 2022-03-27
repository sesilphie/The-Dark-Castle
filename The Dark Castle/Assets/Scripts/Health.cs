using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")] //Buat Header
    public float HP;
    public float currentHP { get; private set; }
    Animator animator;
    private bool dead;

    [Header("iFrames")]
    public float iFramesDuration;
    public float numberOfFlash;
    private SpriteRenderer spriteRender;

    private void Awake()
    {
        currentHP = HP;
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void Damage (float damage)
    {
        currentHP -= damage;

        if (currentHP > 0)
        {
            //player hurt
            animator.SetTrigger("hurt");
            //iframes
            StartCoroutine(AntiDamage());
        }
        else
        {
            if (!dead)
            {
                //player die
                animator.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float health)
    {
        currentHP = Mathf.Clamp(currentHP + health, 0, 5);
    }

    private IEnumerator AntiDamage()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        //Durasi Anti Damage
        for (int i = 0; i < numberOfFlash; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlash * 2));
            spriteRender.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
