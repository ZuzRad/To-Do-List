using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListPanel : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Transform child;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragTask dragTask = dropped.GetComponent<DragTask>();
        dragTask.parentAfterDrag = child;
    }
}
