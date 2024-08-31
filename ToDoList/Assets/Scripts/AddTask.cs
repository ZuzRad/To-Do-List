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

    [SerializeField]
    private TMP_Dropdown categoryInput;

    public event Action<string, string, string> OnTaskAdded;

    private void Start()
    {
        addButton.onClick.AddListener(AddTaskToList);
    }

    private void AddTaskToList()
    {
        string title = titleInput.text;
        string description = desInput.text;
        string category = categoryInput.options[categoryInput.value].text;

        OnTaskAdded?.Invoke(title, description, category);
    }
}
