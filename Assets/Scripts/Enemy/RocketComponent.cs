using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketComponent : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float mySpeed =1000;
    [SerializeField] private int myDamage;

    [Header("Components")]
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineRenderer line;

    void Start()
    {
        transform.LookAt(PlayerController.Instance.transform);
        Vector3 shootPos = (PlayerController.Instance.transform.position - transform.position).normalized;
        rb.AddForce(shootPos * mySpeed);
        Physics.Raycast(transform.position, PlayerController.Instance.transform.position);

       // line.GetPosition(1) = Vector3
    }
    private void OnCollisionEnter(Collision collision)
    {
        CloseComponents();
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                hit.TryGetComponent(out PlayerController player);
                player.takeDamage(myDamage);
            }
        }
    }
    public void CloseComponents()
    {
        Destroy(gameObject, 2);
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
        rb.isKinematic = true;
    }

}
