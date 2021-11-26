using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject virtualCamera;

    private void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Player") && !room.isTrigger)
        {
            virtualCamera.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D room)
    {
        if (room.CompareTag("Player") && !room.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }
}
