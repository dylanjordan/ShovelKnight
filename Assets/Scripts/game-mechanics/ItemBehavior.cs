using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCount.itemAmount++;
        SoundManager.PlaySound("coinImpact");
        Destroy(gameObject);
    }
}

