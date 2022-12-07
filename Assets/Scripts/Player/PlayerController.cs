using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed;

    #region SerializeFields
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private float myStartSpeed;
    #endregion

    private void Start()
    {
        myStartSpeed = speed;
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
    public void EndAttack()
    {
        anim.SetBool("Idle", true);
    }
    public void FalseIdle()
    {
        anim.SetBool("Idle", false);
        navMesh.enabled = true;
        speed = myStartSpeed;
    }
    public void JoyStickMovement()
    {

        if (navMesh.enabled == true)
        {
            Vector3 moveForward = new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical);
            transform.Translate(speed * Time.fixedDeltaTime * moveForward, Space.World);
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
