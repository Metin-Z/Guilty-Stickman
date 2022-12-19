using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectLevelButton : MonoBehaviour
{
    public int levelId;
    public void GetLevel()
    {
        Instantiate(LevelManager.Instance.GetLevels().ElementAt(levelId).Prefab);
        GameManager.Instance.GetNavmesh().BuildNavMesh();
        InterfaceManager.Instance.ClosePanels();
        PlayerController.Instance.StartLevel();
        GameObject spawnPos;
        spawnPos = GameObject.FindGameObjectWithTag("SpawnPlayer");
        spawnPos.TryGetComponent(out SetPlayerSpawnPos setPlayerPos);
        setPlayerPos.TeleportPlayer();
    }

   
}
