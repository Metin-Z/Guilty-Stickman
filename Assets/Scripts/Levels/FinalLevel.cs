using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    [SerializeField] private int levelId;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InterfaceManager.Instance.GetMenuCanvas().SetActive(true);
            InterfaceManager.Instance.GetMenuCanvas().SetActive(true);
            if (levelId > PlayerPrefs.GetInt("LevelID"))
            {
                PlayerPrefs.SetInt("LevelID", levelId);
            }
            GameObject level;
            level =GameObject.FindGameObjectWithTag("Level");
            Destroy(level);
            Debug.Log("Level Tamamlandý");
        }
    }
}
