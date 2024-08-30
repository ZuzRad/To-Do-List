using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListManager : MonoBehaviour
{
    [SerializeField]
    private AddTask addTaskRef;

    [SerializeField]
    private GameObject taskPrefab;

    [SerializeField]
    private Transform taskListParent;

    private void OnEnable()
    {
        addTaskRef.OnTaskAdded += CreateNewTask;
    }

    private void OnDisable()
    {
        addTaskRef.OnTaskAdded -= CreateNewTask;
    }

    private void CreateNewTask(string title, string description)
    {
        GameObject newTaskObject = Instantiate(taskPrefab, taskListParent);

        Task newTask = newTaskObject.GetComponent<Task>();
        newTask.SetTask(title, description);
    }
}
