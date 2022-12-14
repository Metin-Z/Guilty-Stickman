using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFollower : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;

    public Transform GetIndicatorTarget()
    {
        return target;
    }
    private void Update()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position),
           rotationSpeed * Time.deltaTime);
        }
        
    }
}
