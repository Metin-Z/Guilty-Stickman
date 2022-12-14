using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    #region

    [SerializeField] private GameObject FirstTask;
    [SerializeField] private GameObject SecondTask;


    [SerializeField] private GameObject completeIcon;
    [SerializeField] private GameObject lockIcon;

    [SerializeField] private GameObject CurrentTask;
    #endregion
    private void Update()
    {
        PlayerController.Instance.GetPlayerIndicator().TryGetComponent(out TaskFollower indicator);
        if (FirstTask == null && CurrentTask == null)
        {
            CurrentTask = SecondTask;
            completeIcon.SetActive(true);
            SecondTask.SetActive(true);
            lockIcon.SetActive(false);

        }
        if (CurrentTask != null)
        {
            indicator.target = CurrentTask.transform;
        }
    }

}