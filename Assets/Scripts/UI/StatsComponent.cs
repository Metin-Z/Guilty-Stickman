using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsComponent : MonoBehaviour
{
    [SerializeField] private statType statType;
    [SerializeField] private TextMeshProUGUI stat_TXT;


    private void Start()
    {
        switch (statType)
        {
            case statType.Axeman:
                stat_TXT.text = PlayerPrefs.GetInt("AxemanCount").ToString();
                break;
            case statType.Archer:
                stat_TXT.text = PlayerPrefs.GetInt("ArcherCount").ToString();
                break;
        }
    }
}
