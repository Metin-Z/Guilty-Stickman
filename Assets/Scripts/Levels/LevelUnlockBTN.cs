using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockBTN : MonoBehaviour
{
    [SerializeField] private int levelID;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelID") >= levelID-1)
        {
            gameObject.SetActive(false);
        }
    }
}
