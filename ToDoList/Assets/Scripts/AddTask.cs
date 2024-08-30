using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class AddTask : MonoBehaviour
{
    [SerializeField]
    private Button addButton;
    [SerializeField]
    private TMP_Text titleInput;
    [SerializeField]
    private TMP_Text desInput;

    public event Action<string, string> OnTaskAdded;

    private void Start()
    {
        addButton.onClick.AddListener(AddTaskToList);
    }

    private void AddTaskToList()
    {
        string title = titleInput.text;
        string description = desInput.text;

        OnTaskAdded?.Invoke(title, description);
    }
}
