using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;

    #region SerializeFields

    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI mainMoney_TXT;
    [SerializeField] private GameObject level_Panel;
    [SerializeField] private GameObject cosmetics_Panel;
    #endregion

    public virtual void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateMoney();
    }

    public TextMeshProUGUI GetMoneyText()
    {
        return mainMoney_TXT;
    }
    public void UpdateMoney()
    {
        mainMoney_TXT.text = $"{PlayerPrefs.GetInt("Money")}";
    }

    public void OpenMenu()
    {
        level_Panel.SetActive(false);
        cosmetics_Panel.SetActive(false);
    }
    public void LevelPanel()
    {
        level_Panel.SetActive(true);
        cosmetics_Panel.SetActive(false);
    }
    public void CosmeticsPanel()
    {
        level_Panel.SetActive(false);
        cosmetics_Panel.SetActive(true);
    }
}
