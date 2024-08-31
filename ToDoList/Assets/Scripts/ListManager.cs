using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListManager : MonoBehaviour
{
    [SerializeField]
    private AddTask addTaskRef;

    [SerializeField]
    private SearchTask searchTaskRef;

    [SerializeField]
    private GameObject taskPrefab;

    [SerializeField]
    private Transform taskListParent;

    public List<GameObject> listToSearch = new List<GameObject>();

    private void OnEnable()
    {
        addTaskRef.OnTaskAdded += CreateNewTask;
        searchTaskRef.OnTaskSearch += HideTasks;
    }

    private void OnDisable()
    {
        addTaskRef.OnTaskAdded -= CreateNewTask;
        searchTaskRef.OnTaskSearch -= HideTasks;
    }

    private void CreateNewTask(string title, string description)
    {
        GameObject newTaskObject = Instantiate(taskPrefab, taskListParent);
        listToSearch.Add(newTaskObject);

        Task newTask = newTaskObject.GetComponent<Task>();
        newTask.SetTask(title, description);

        searchTaskRef.AddTaskToSearch(newTask);
    }

    private void HideTasks(List<int> indexes)
    {
        foreach (GameObject task in listToSearch)
        {
            task.SetActive(true);
        }

        foreach (int index in indexes)
        {
            GameObject task = listToSearch[index];
            task.SetActive(false);
        }
    }
}
