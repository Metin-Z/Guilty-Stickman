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
    [SerializeField] private float arrowSpeed;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform arrowPos;
    private float startSpeed;
    bool active = true;
    private void Start()
    {
        switch (enemyType)
        {
            case enemyType.Axeman:
                StartCoroutine(AxemanControl());
                startSpeed = navMesh.speed;
                break;
            case enemyType.Archer:
                StartCoroutine(ArcherControl());
                break;
            case enemyType.Bomber:
                StartCoroutine(BomberControl());
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
                if (Mathf.Abs(distance) <= 3.5f)
                {
                    navMesh.speed = 0;
                    anim.SetBool("Walk", false);
                    anim.SetBool("Attack", true);
                    transform.LookAt(player.transform);
                }
                else
                {
                    navMesh.speed = startSpeed;
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
                transform.LookAt(player.transform);

            }
            else
            {
                anim.SetBool("Shoot", false);
            }
        }
    }
    public void ShootPlayer()
    {
        Vector3 arrowSpawnPos = new Vector3(arrowPos.transform.position.x, arrowPos.transform.position.y, arrowPos.transform.position.z);
        GameObject arrow;
        arrow = Instantiate(arrowPrefab, arrowSpawnPos,Quaternion.identity);
        arrow.TryGetComponent(out Rigidbody rb);
        rb.AddForce(transform.forward * arrowSpeed);
    }
    public void LookPlayer()
    {
        transform.LookAt(PlayerController.Instance.transform);
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
            Vector3 CoinSpawnPos = new Vector3(transform.position.x, PlayerController.Instance.transform.position.y, transform.position.z);
            switch (enemyType)
            {
                case enemyType.Axeman:
                    PlayerPrefs.SetInt("AxemanCount",PlayerPrefs.GetInt("AxemanCount")+1);
                    break;
                case enemyType.Archer:
                    PlayerPrefs.SetInt("ArcherCount", PlayerPrefs.GetInt("ArcherCount") + 1);
                    break;
            }
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
    public IEnumerator BomberControl()
    {
        while (active == true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
        }
    }
}
