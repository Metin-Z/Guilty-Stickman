using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
    [SerializeField] private int myDamage;
    [SerializeField] private bool arrow;
    private void Start()
    {
        if (arrow == true)
        {
            transform.LookAt(PlayerController.Instance.transform.position);
            Destroy(gameObject,3.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.TryGetComponent(out PlayerController player);
            player.takeDamage(myDamage);
            if (arrow == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
