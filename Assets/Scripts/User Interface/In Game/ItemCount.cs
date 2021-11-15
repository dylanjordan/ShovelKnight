using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    Text text;
    public static int itemAmount;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            itemAmount++;
        }
        text.text = itemAmount.ToString();
    }
}
