using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed;

    #region SerializeFields
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private float myStartSpeed;
    [SerializeField] private List<GameObject> Swords;
    [SerializeField] private List<GameObject> Hats;
    #endregion

    private void Start()
    {
        myStartSpeed = speed;
        foreach (var item in Swords)
        {
            item.gameObject.SetActive(true);
        }
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
}
