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

    private List<GameObject> listToSearch = new List<GameObject>();


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
        listToSearch.Add(newTaskObject);

        Task newTask = newTaskObject.GetComponent<Task>();
        newTask.SetTask(title, description, newcategory);

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
