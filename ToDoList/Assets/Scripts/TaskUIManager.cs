using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskUIManager : MonoBehaviour, IPointerClickHandler
{
    [Header("UI components")]
    [SerializeField]
    private TMP_Text titleText;

    [SerializeField]
    private TMP_Text descriptionText;

    [SerializeField]
    private TMP_Text categoryText;

    [SerializeField]
    private Button deleteButton;

    [SerializeField]
    private GameObject descriptionGO;

    private RectTransform rectTransform;
    private bool isExpanded = false;
    private Task task;

    public void Initialize(Task task)
    {
        this.task = task;
        SetText(task.Title, task.Description, task.Category);
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        deleteButton.onClick.AddListener(DeleteTask);
        descriptionGO.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            ToggleExpand();
        }
    }

    private void ToggleExpand()
    {
        ToggleDescription(isExpanded ? 100 : 200);

        isExpanded = !isExpanded;
    }

    private void ToggleDescription(int height)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
        descriptionGO.SetActive(!isExpanded);
    }


    private void DeleteTask()
    {
        task.Delete();
        Destroy(gameObject);
    }

    public void SetText(string title, string description, string category)
    {
        this.titleText.text = title;
        this.descriptionText.text = description;
        this.categoryText.text = category;
    }
}
