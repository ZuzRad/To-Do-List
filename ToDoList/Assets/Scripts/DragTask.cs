using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragTask : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image image;
    [HideInInspector] public Transform parentAfterDrag;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 offset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.root as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint);

        offset = rectTransform.anchoredPosition - localPoint;

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.root as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint);

        rectTransform.anchoredPosition = localPoint + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        canvasGroup.blocksRaycasts = true;
    }
}

