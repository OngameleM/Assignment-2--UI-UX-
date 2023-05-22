using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    

    [Header("UI")]
    public Image image;
    public Text countText;

    [SerializeField] private Canvas canvas;


    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;

   

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image; 
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup> ();
    }
    public void OnBeginDrag(PointerEventData eventData) 
    {
        print("OnBeginDrag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.parent.parent.parent.parent);
        transform.SetAsLastSibling();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        print("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        print("onPointerDown");
    }
}

