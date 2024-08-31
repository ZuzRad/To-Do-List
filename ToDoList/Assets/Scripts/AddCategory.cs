using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddCategory : MonoBehaviour
{
    [Header("UI components")]
    [SerializeField]
    private TMP_Dropdown categoryDropdown;

    [SerializeField]
    private TMP_Text categoryInput;

    [SerializeField]
    private Button addButton;

    private void Start()
    {
        addButton.onClick.AddListener(AddCategoryToDropdown);
    }

    private void AddCategoryToDropdown()
    {
        string newCategory = categoryInput.text.Trim();

        if (!string.IsNullOrEmpty(newCategory))
        {
            bool categoryExists = categoryDropdown.options.Exists(option => option.text.Equals(newCategory, System.StringComparison.OrdinalIgnoreCase));

            if (!categoryExists) 
            {
                categoryDropdown.options.Add(new TMP_Dropdown.OptionData(newCategory));
                categoryDropdown.RefreshShownValue();
                categoryInput.text = string.Empty;
            }
        }
    }
}
