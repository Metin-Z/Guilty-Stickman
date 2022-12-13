using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform camera;
    void Update()
    {
        transform.LookAt(camera);
    }
}
