using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyComponent : MonoBehaviour
{
    [SerializeField] private float targetRange;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject coinPrefab;

    [Header("Health")]
    [SerializeField] private Slider HealthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private float baseHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private enemyType enemyType;
    bool active = true;
    private void Start()
    {
        switch (enemyType)
        {
            case enemyType.Axeman:
                StartCoroutine(AxemanControl());
                break;
            case enemyType.Archer:
                StartCoroutine(ArcherControl());
                break;
        }
    }
    public IEnumerator AxemanControl()
    {
        while (active == true)
        {
            yield return new WaitForFixedUpdate();
            GameObject player = PlayerController.Instance.gameObject;
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (Mathf.Abs(distance) < targetRange)
            {
                anim.SetBool("Walk", true);
                navMesh.SetDestination(player.transform.position);
                if (Mathf.Abs(distance) <= 3)
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("Attack", true);
                    transform.LookAt(player.transform);
                }
                else
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Walk", true);
                }
            }
            else
            {
                anim.SetBool("Walk", false);
            }
        }
    }
    public IEnumerator ArcherControl()
    {
        while (active == true)
        {
            yield return new WaitForFixedUpdate();
            GameObject player = PlayerController.Instance.gameObject;
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (Mathf.Abs(distance) < targetRange)
            {
                transform.LookAt(player.transform.position);

                anim.SetBool("Shoot", true);
                anim.SetBool("Attack", true);
                transform.LookAt(player.transform);

            }
            else
            {
                anim.SetBool("Shoot", false);
            }
        }
    }
    public void Health()
    {
        HealthBar.maxValue = maxHealth;
        HealthBar.DOValue(currentHealth, 0.5f);
        if (currentHealth <= 0)
        {
            anim.SetBool("Death", true);
            anim.SetBool("Walk", false);
            gameObject.TryGetComponent(out BoxCollider collider);
            gameObject.TryGetComponent(out Rigidbody rb);
            collider.enabled = false;
            rb.velocity = Vector3.zero;
            currentHealth = baseHealth;
            PlayerController.Instance.regen(7);
            Vector3 CoinSpawnPos = new Vector3(Random.Range(transform.position.x, transform.position.x + 3), PlayerController.Instance.transform.position.y, Random.Range(transform.position.z, transform.position.z + 3));

            Instantiate(coinPrefab, CoinSpawnPos, Quaternion.identity);
            Destroy(gameObject, 2);
        }
    }
    public void takeDamage(int takenDamage)
    {
        currentHealth -= takenDamage;
        Health();
    }
    public void regen(int regenValue)
    {
        currentHealth += regenValue;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Health();
    }
}
