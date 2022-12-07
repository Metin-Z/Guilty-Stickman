using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameManager instance;

    #region SerializeFields

    [Header("Objects")]
    [SerializeField] private PlayerController Player;

    [Header("Values")]
    [SerializeField] private int mainMoney;
    #endregion


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            IncreaseMoney(50);
        }
    }
    public PlayerController GetPlayer()
    {
        return Player;
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