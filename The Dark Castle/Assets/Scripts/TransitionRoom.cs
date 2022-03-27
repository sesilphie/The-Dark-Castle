using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionRoom : MonoBehaviour
{
    public Transform PreviousRoom;
    public Transform NextRoom;
    public CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MoveToNewRoom(NextRoom);
            else
                cam.MoveToNewRoom(PreviousRoom);
        }
    }
}
