using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ItemCount.itemAmount++;
            SoundManager.PlaySound("coinImpact");
            Destroy(gameObject);
        }
    }
}


