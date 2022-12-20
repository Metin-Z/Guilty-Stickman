using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinItem : MonoBehaviour
{
    public int price;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseMoney(price);
            transform.DOScale(0, 0.5f);
            Destroy(gameObject, 1.3f);
        }
    }
}
