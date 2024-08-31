using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SearchTask : MonoBehaviour
{
    [SerializeField]
    private Button searchButton;

    [SerializeField]
    private TMP_Text searchInput;

    public List<Task> listToSearch = new List<Task>();

    public List<int> indexesToHide = new List<int>();

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
        if (searchText != "")
        {
            for (int i = 0; i < listToSearch.Count; i++)
            {
                Task task = listToSearch[i];
                if (!task.Title.ToLower().Contains(searchText))
                {
                    indexesToHide.Add(i);
                }
            }
        }


        OnTaskSearch?.Invoke(indexesToHide);
    }
}
