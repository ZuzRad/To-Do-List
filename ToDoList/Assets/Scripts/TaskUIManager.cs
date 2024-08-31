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
    private Button deleteButton;

    [SerializeField]
    private GameObject descriptionGO;

    private RectTransform rectTransform;
    private bool isExpanded = false;

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
        if (isExpanded)
        {
            ToggleDescription(100);
        }
        else
        {
            ToggleDescription(200);
        }

        isExpanded = !isExpanded;
    }

    private void ToggleDescription(uint height)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
        descriptionGO.SetActive(!isExpanded);
    }


    private void DeleteTask()
    {
        Destroy(gameObject);
    }

    public void SetText(string title, string description)
    {
        this.titleText.text = title;
        this.descriptionText.text = description;
    }
}
