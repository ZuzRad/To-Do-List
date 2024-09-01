using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField]
    private TaskUIManager UiManager;

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }

    public event Action<Task> OnTaskDelete;

    private void OnEnable()
    {
        UiManager.OnTaskDelete += CallOnTaskDelete;
    }

    private void OnDisable()
    {
        UiManager.OnTaskDelete -= CallOnTaskDelete;
    }
    public void SetTask(string newTitle, string newDescription, string newcategory)
    {
        Title = newTitle;
        Description = newDescription;
        Category = newcategory;
        UiManager?.SetText(Title, Description, Category);
    }

    private void CallOnTaskDelete(Task task)
    {
        OnTaskDelete?.Invoke(task);
    }
}
