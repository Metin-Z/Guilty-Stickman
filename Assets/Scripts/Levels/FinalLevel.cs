using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class FinalLevel : MonoBehaviour
{
    [SerializeField] private int levelId;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (levelId > PlayerPrefs.GetInt("LevelID"))
            {
                PlayerPrefs.SetInt("LevelID", levelId);
            }
            Wait();
        }
    }
    public async void Wait()
    {
        await Task.Delay(2 * 1000);
        SceneManager.LoadScene(0);
    }
}
