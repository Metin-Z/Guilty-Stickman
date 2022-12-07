using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectLevelButton : MonoBehaviour
{
    public int levelId;
    public void GetLevel()
    {
        InterfaceManager.Instance.ClosePanels();
        //Instantiate(LevelManager.Instance.GetLevels().ElementAt(levelId).Prefab);
        Instantiate(LevelManager.Instance.GetLevels().SingleOrDefault().Prefab);
        GameManager.Instance.GetPlayer().transform.position = LevelManager.Instance.GetPlayerSpawnPos().position;
    }
}
