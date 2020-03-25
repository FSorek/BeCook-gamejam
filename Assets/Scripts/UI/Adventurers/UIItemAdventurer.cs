using Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItemAdventurer : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Image _image;
    
    private Item _item;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private UIAdventurerInventorySlot _beginDragSlot;
    public Item Item => _item;

    public UIAdventurerInventorySlot CurrentUIInventorySlot;
    public RectTransform RectTransform { get; private set; }
    
    public AdventurerInventory AdventurerInventory { get; private set; }
    
    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(Item item,UIAdventurerInventorySlot uiInventorySlot,AdventurerInventory adventurerInventory)
    {
        _item = item;
        _image.sprite = item.Sprite;
        CurrentUIInventorySlot = uiInventorySlot;
        AdventurerInventory = adventurerInventory;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
        _beginDragSlot = CurrentUIInventorySlot;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        if (_beginDragSlot == CurrentUIInventorySlot)
        {
            ReturnToCurrentSlotPosition();
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta/_canvas.scaleFactor;
    }
    
    private void ReturnToCurrentSlotPosition()
    {
        RectTransform.position = CurrentUIInventorySlot.RectTransform.position;
    }
}