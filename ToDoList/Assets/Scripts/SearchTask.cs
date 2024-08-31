using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class SearchTask : MonoBehaviour
{
    [SerializeField]
    private Button searchButton;

    [SerializeField]
    private TMP_InputField searchInput;

    [SerializeField]
    private Toggle descriptionToggle;

    private List<Task> listToSearch = new List<Task>();

    private List<int> indexesToHide = new List<int>();

    public event Action<List<int>> OnTaskSearch;

    private void Start()
    {
        searchButton.onClick.AddListener(SearchTaskClick);
    }

    public void AddTaskToSearch(Task task)
    {
        listToSearch.Add(task);
    }

    private void SearchTaskClick()
    {
        string searchText = searchInput.text.Trim().ToLower();
        indexesToHide.Clear();
        if (!string.IsNullOrEmpty(searchText))
        {
            indexesToHide = listToSearch
                .Select((task, index) => new { task, index })
                .Where(item =>
                    item.task.Title.Trim().ToLower().IndexOf(searchText) == -1 &&
                    (!descriptionToggle.isOn || item.task.Description.Trim().ToLower().IndexOf(searchText) == -1))
                .Select(item => item.index)
                .ToList();
        }

        OnTaskSearch?.Invoke(indexesToHide);
    }
}
