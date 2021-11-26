using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    Text text;
    public static int itemAmount = 0;
    void Start()
    {
        itemAmount = 0;
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = itemAmount.ToString();
    }
}
