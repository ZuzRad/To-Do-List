using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{

    private string title;
    private string description;
    [SerializeField]
    private TaskUIManager uiManager;

    public void SetTask(string newTitle, string newDescription)
    {
        title = newTitle;
        description = newDescription;
        uiManager.SetText(title, description);
    }
}
