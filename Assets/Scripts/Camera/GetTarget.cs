using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GetTarget : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinem;

    private void Start()
    {
        cinem.Follow = PlayerController.Instance.transform;
        cinem.LookAt = PlayerController.Instance.transform;
        PlayerController.Instance.FalseDeath();
    }
}
