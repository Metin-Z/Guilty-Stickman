using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanels : MonoBehaviour
{
    [SerializeField] private GameObject swordPanel;
    [SerializeField] private GameObject hatPanel;



    public void OpenSwordPanel()
    {
        swordPanel.SetActive(true);
        hatPanel.SetActive(false);
    }
    public void OpenHatPanel()
    {
        swordPanel.SetActive(false);
        hatPanel.SetActive(true);
    }
}
