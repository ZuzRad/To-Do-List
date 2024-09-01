using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListManager : MonoBehaviour
{
    public static ListManager Instance { get; private set; }

    [Header("UI components")]
    [SerializeField]
    private AddTask addTaskRef;

    [SerializeField]
    private SearchTask searchTaskRef;

    [SerializeField]
    private GameObject taskPrefab;

    [SerializeField]
    private Transform taskListParent;

    private List<Task> listToSearch = new();


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

        listToSearch.Add(newTask);
        searchTaskRef.AddTaskToSearch(newTask);
    }

    private void DeleteTaskFromList(Task task)
    {
        searchTaskRef.DeleteTaskFromList(task);
        listToSearch.Remove(task);
        task.OnTaskDelete -= DeleteTaskFromList;
    }

    private void HideTasks(List<int> indexes)
    {
        foreach (Task task in listToSearch)
        {
            task.gameObject.SetActive(true);
        }

        foreach (int index in indexes)
        {
            Task task = listToSearch[index];
            task.gameObject.SetActive(false);
        }
    }
}
