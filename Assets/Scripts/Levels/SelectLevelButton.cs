using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectLevelButton : MonoBehaviour
{
    public int levelId;
    public void GetLevel()
    {
        Instantiate(LevelManager.Instance.GetLevels().SingleOrDefault().Prefab);
        InterfaceManager.Instance.ClosePanels();
        PlayerController.Instance.StartLevel();
        GameManager.Instance.GetNavmesh().BuildNavMesh();
    }

   
}
