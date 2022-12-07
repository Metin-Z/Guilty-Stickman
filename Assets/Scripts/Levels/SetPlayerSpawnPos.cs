using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawnPos : MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.GetPlayerSpawnPos().transform.position = transform.position;
    }
}
