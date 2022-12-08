using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public string itemName;
    void Start()
    {
        if (PlayerPrefs.GetInt("sword0select") ==1 && itemName == "sword0")
        {
            transform.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("sword0select") != 1 && itemName == "sword0")
        {
            transform.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("sword1select") == 1 && itemName == "sword1")
        {
            transform.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("sword1select") != 1 && itemName == "sword1")
        {
            transform.gameObject.SetActive(false);
        }
    }

    
}
