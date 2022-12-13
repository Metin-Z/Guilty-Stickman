using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public int itemID;
    public bool hat;
    public bool sword;
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("swordSelect"));
        Debug.Log(itemID);

        ResetItem();
    }

    public void ResetItem()
    {
        if (sword == true)
        {
            if (PlayerPrefs.GetInt("swordSelect") == itemID)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }

            if (PlayerPrefs.GetInt("swordSelect") != itemID)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (hat == true)
        {
            if (PlayerPrefs.GetInt("hatSelect") == itemID)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }

            if (PlayerPrefs.GetInt("hatSelect") != itemID)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

}
