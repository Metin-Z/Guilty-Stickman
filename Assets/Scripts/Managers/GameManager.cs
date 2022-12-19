using UnityEngine;
using UnityEngine.AI;

public class GameManager : Singleton<GameManager>
{
    #region SerializeFields

    [Header("Objects")]
    [SerializeField] private PlayerController Player;
    [SerializeField] private NavMeshSurface NavMeshSurface;
    [SerializeField] private Camera mainCamera;

    [Header("Values")]
    [SerializeField] private int mainMoney;
    #endregion

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("LevelID"));
        Player = PlayerController.Instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            IncreaseMoney(50);
        }
    }
    public Camera GetCamera()
    {
        return mainCamera;
    }
    public PlayerController GetPlayer()
    {
        return Player;
    }
    public NavMeshSurface GetNavmesh()
    {
        return NavMeshSurface;
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