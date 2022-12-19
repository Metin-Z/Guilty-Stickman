using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : Singleton<InterfaceManager>
{
    public static InterfaceManager instance;

    #region SerializeFields

    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI mainMoney_TXT;


    [SerializeField] private GameObject GameCanvas;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private GameObject failCanvas;
    
    
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject moneyCanvas;
    
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
        MenuPanel.SetActive(true);
        moneyCanvas.SetActive(true);
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
    public DynamicJoystick GetJoyStick()
    {
        return dynamicJoystick;
    }
    public GameObject GetGameCanvas()
    {
        return GameCanvas;
    }
    public GameObject GetFailCanvas()
    {
        return failCanvas;
    }
    public GameObject GetMenuCanvas()
    {
        return MenuPanel;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
    public void ClosePanels()
    {
        MenuPanel.SetActive(false);
        moneyCanvas.SetActive(false);
        levelsPanel.SetActive(false);
        GameCanvas.SetActive(true);
    }
}
