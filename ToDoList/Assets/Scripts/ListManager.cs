using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListManager : MonoBehaviour
{
    public static ListManager Instance { get; private set; }

    [Header("References to other scripts")]
    [SerializeField]
    private AddTask addTaskRef;

    [SerializeField]
    private SearchTask searchTaskRef;

    [Header("Task prefab settings")]
    [SerializeField]
    private GameObject taskPrefab;

    [SerializeField]
    private Transform taskListParent;

    private List<Task> tasksList = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    private void CreateNewTask(string title, string description, string newcategory)
    {
        GameObject newTaskObject = Instantiate(taskPrefab, taskListParent);

        Task newTask = newTaskObject.GetComponent<Task>();

        newTask.SetTask(title, description, newcategory);

        newTask.OnTaskDelete += DeleteTaskFromList;

        tasksList.Add(newTask);
        searchTaskRef.AddTaskToSearch(newTask);
    }

    private void DeleteTaskFromList(Task task)
    {
        searchTaskRef.DeleteTaskFromList(task);
        tasksList.Remove(task);
        task.OnTaskDelete -= DeleteTaskFromList;
    }

    private void HideTasks(List<int> indexes)
    {
        foreach (Task task in tasksList)
        {
            task.gameObject.SetActive(true);
        }

        foreach (int index in indexes)
        {
            Task task = tasksList[index];
            task.gameObject.SetActive(false);
        }
    }
}
