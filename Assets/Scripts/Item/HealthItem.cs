using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthItem : MonoBehaviour
{
    public int myRegen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.TryGetComponent(out PlayerController player);
            player.regen(myRegen);
            transform.DOScale(0, 0.5f);
            Destroy(gameObject, 0.6f);
        }
    }
}
