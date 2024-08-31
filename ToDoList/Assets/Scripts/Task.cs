using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField]
    private TaskUIManager uiManager;

    public string Title { get; private set; }
    public string Description { get; private set; }

    public void SetTask(string newTitle, string newDescription)
    {
        Title = newTitle;
        Description = newDescription;
        uiManager?.SetText(Title, Description);
    }
}
