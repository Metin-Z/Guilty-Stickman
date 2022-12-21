using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketComponent : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float mySpeed =1000;
    [SerializeField] private int myDamage;

    [Header("Objects")]
    [SerializeField] private GameObject explosion;

    [Header("Components")]
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private LineRenderer line;
    [SerializeField] private Vector3 playerPos;
    //[SerializeField] private int lineSegment =10;

    void Start()
    {
        transform.LookAt(PlayerController.Instance.transform);
        //Vector3 shootPos = (PlayerController.Instance.transform.position - transform.position).normalized;
        //rb.AddForce(shootPos * mySpeed);
        playerPos = PlayerController.Instance.transform.position;
        //line.positionCount = lineSegment;
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
        Instantiate(explosion, transform.position, Quaternion.identity);

    }
    public void CloseComponents()
    {
        Destroy(gameObject, 2);
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
        line.enabled = false;
        rb.isKinematic = true;
    }
    private void Update()
    {
        //Visualize(transform.position);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, 35 * Time.deltaTime);
        line.SetPosition(0,new Vector3(0,0,0));
        line.SetPosition(1, new Vector3(0, 0, playerPos.z * 5));
    }
    //void Visualize(Vector3 vo)
    //{
    //    for (int i = 0; i < lineSegment; i++)
    //    {
    //        Vector3 pos = CalculatorPosInTime(vo, i / (float)lineSegment);
    //        line.SetPosition(i, pos);
    //    }
    //}
    //Vector3 CalculatorPosInTime(Vector3 vo,float time)
    //{
    //    Vector3 Vxz = vo;
    //    vo.y = 0f;

    //    Vector3 result = PlayerController.Instance.transform.position + vo * time;
    //    float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + PlayerController.Instance.transform.position.y;
    //    result.y = sY;

    //    return result;
    //}
}
