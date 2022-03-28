using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")] //Buat Header
    public float HP;
    public float currentHP { get; private set; }
    Animator animator;
    private bool dead ;

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

            //BossEnemy hurt
            animator.SetTrigger("bossHurt");
            //iframes
            StartCoroutine(AntiDamage());
        }
        else
        {
            if (!dead)
            {
                //Minion Orange Die
                if (GetComponent<EnemySideWays>() != null)
                {
                    //GetComponent<EnemySideWays>().enabled = false;
                    //animator.SetTrigger("dieMinionOrange");
                    Destroy(gameObject);
                }

                //player
                if (GetComponent<PlayerMovement>() != null)
                {
                    //Reset Scene atau restart gameplay
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    GetComponent<PlayerMovement>().enabled = false;
                    //player die
                    animator.SetTrigger("die");
                }
                  
                //boss enemy
                if (GetComponentInParent<BossPatrol>() != null)
                {
                    GetComponentInParent<BossPatrol>().enabled = false;
                }

                //Boss Enemy Die
                if (GetComponent<BossEnemy>() != null)
                {
                    GetComponent<BossEnemy>().enabled = false;
                    animator.SetTrigger("bossDie");
                }
                
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
