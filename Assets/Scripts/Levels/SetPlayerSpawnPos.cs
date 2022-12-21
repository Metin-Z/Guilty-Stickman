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
    private void Update()
    {
        PlayerController.Instance.transform.position = transform.position;
    }
    public IEnumerator Tplayer()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
