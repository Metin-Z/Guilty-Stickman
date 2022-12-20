using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    public DynamicJoystick dynamicJoystick;
    public float speed;

    #region SerializeFields
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private float myStartSpeed;



    [SerializeField] private GameObject Indicator;

    [SerializeField] private List<GameObject> Swords;
    [SerializeField] private List<GameObject> Hats;

    [Header("Health")]
    [SerializeField] private Slider HealthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private float baseHealth;
    [SerializeField] private float currentHealth;

    #endregion

    private void Start()
    {
        Health();
        baseHealth = maxHealth;
        myStartSpeed = speed;
    }
    public void FalseDeath()
    {
        dynamicJoystick = InterfaceManager.Instance.GetJoyStick();
        anim.SetBool("Death", false);
        gameObject.TryGetComponent(out BoxCollider collider);
        collider.enabled = true;
    }
    private void Update()
    {
        JoyStickMovement();

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Walk", false);
            speed = 0;
            navMesh.enabled = false;
            anim.SetTrigger("Attack");
        }
    }
    public List<GameObject> GetSwords()
    {
        return Swords;
    }
    public List<GameObject> GetHats()
    {
        return Hats;
    }
    public GameObject GetPlayerIndicator()
    {
        return Indicator;
    }
    public Animator GetAnimator()
    {
        return anim;
    }
    public void EndAttack()
    {
        anim.SetBool("Idle", true);
        navMesh.enabled = true;
        speed = myStartSpeed;
    }
    public void FalseIdle()
    {
        anim.SetBool("Idle", false);
    }
    public void JoyStickMovement()
    {

        if (speed > 0)
        {
            Vector3 moveForward = new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical);
            transform.Translate(speed * Time.deltaTime * moveForward, Space.World);
            moveForward.Normalize();
            if (dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
            {
                transform.forward = moveForward;
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }
        }
    }
    public void StartLevel()
    {
        currentHealth = maxHealth;
        speed = myStartSpeed;
        Health();
    }

    public void Health()
    {
        HealthBar.maxValue = maxHealth;
        HealthBar.DOValue(currentHealth,0.5f);
        if (currentHealth <= 0)
        {
            anim.SetBool("Death",true);
            anim.SetBool("Walk", false);
            gameObject.TryGetComponent(out BoxCollider collider);
            gameObject.TryGetComponent(out Rigidbody rb);
            collider.enabled = false;
            rb.velocity = Vector3.zero;
            InterfaceManager.Instance.GetGameCanvas().SetActive(false);
            currentHealth = baseHealth;
            StartCoroutine(FailLevel());
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
    public IEnumerator FailLevel()
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(0, 0, 0);
        Time.timeScale = 0;
        InterfaceManager.Instance.GetFailCanvas().SetActive(true);
    }
}
