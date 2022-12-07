using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform playerSpawnPos;
    [SerializeField] private List<Level> Levels;
    public void Start()
    {
        InitializeLevel();
    }
    public List<Level> GetLevels()
    {
        return Levels;
    }
    public Transform GetPlayerSpawnPos()
    {
        return playerSpawnPos;
    }
    public void InitializeLevel()
    {       

    } 
}