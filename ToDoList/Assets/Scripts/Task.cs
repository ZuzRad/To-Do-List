using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }

    public event Action<Task> OnTaskDelete;


    public void SetTask(string newTitle, string newDescription, string newcategory)
    {
        Title = newTitle;
        Description = newDescription;
        Category = newcategory;
        TaskUIManager taskUIManager = GetComponent<TaskUIManager>();
        taskUIManager.Initialize(this);
    }

    public void Delete()
    {
        OnTaskDelete?.Invoke(this);
    }
}
