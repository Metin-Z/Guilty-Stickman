using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawnPos : MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.GetPlayerSpawnPos().transform.position = transform.position;
        StartCoroutine(TeleportPlayer());
    }

    public IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.GetPlayer().transform.position = LevelManager.Instance.GetPlayerSpawnPos().position;
    }
}
