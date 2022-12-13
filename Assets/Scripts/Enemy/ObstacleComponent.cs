using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
    [SerializeField] private int myDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.TryGetComponent(out PlayerController player);
            player.takeDamage(myDamage);
        }
    }
}
