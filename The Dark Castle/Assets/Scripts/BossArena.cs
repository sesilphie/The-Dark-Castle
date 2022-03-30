using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArena : MonoBehaviour
{
    public GameObject PembatasBossArena;

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.CurrentState == GameState.States.BossArena)
        {
            PembatasBossArena.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameState.Instance.CurrentState = GameState.States.BossArena;
        }
    }
}
