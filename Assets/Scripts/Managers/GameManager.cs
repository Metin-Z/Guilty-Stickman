using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region SerializeFields
    [Header("Objects")]
    //[SerializeField] private PlayerController _player;

    [Header("Values")]
    [SerializeField] private int mainMoney;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            IncreaseMoney(50);
        }
    }
    public int GetMoney()
    {
        return mainMoney;
    }
    public void IncreaseMoney(int money)
    {
        mainMoney += money;
        PlayerPrefs.SetInt("Money", mainMoney);
        InterfaceManager.instance.UpdateMoney();
    }
    public void DecreaseMoney(int money)
    {
        mainMoney -= money;
        PlayerPrefs.SetInt("Money", mainMoney);
        InterfaceManager.instance.UpdateMoney();
    }
}