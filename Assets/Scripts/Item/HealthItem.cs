using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthItem : MonoBehaviour
{
    public int myRegen;
    [SerializeField] private DOTweenAnimation anim1;
    [SerializeField] private DOTweenAnimation anim2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.TryGetComponent(out PlayerController player);
            player.regen(myRegen);
            anim1.enabled = false;
            anim2.enabled = false;
            transform.DOScale(0, 0.5f);
            Destroy(gameObject, 0.6f);
        }
    }
}
