using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawnPos : MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.GetPlayerSpawnPos().transform.position = transform.position;
    }
    public void TeleportPlayer()
    {
        StartCoroutine(Tplayer());

    }
    public IEnumerator Tplayer()
    {
        yield return new WaitForSeconds(0.2f);
        PlayerController.Instance.transform.position = transform.position;
    }
}
