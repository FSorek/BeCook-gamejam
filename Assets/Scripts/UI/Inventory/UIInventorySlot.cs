using System;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private UIItem _uiItemPrefab;
    [SerializeField] private RectTransform _uiItemParent;


    private UIItem _uiItem;

    public UIItem CurrentUIItem => _uiItem;


    private UIInventory _uiInventory;
    public bool IsEmpty => _uiItem == null;

    public RectTransform RectTransform { get; private set; }

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        _uiInventory = GetComponentInParent<UIInventory>();
    }


    public void CreateAndSetUIItem( Item item)
    {
        _uiItem = Instantiate(_uiItemPrefab,_uiItemParent);
        _uiItem.Initialize(item,this);
    }

    public void Clear()
    {
        _uiItem = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        var uiItem = eventData.pointerDrag.GetComponent<UIItem>();
        
        var uiItemAdventurer =eventData.pointerDrag.GetComponent<UIItemAdventurer>();

        if (uiItem == null && uiItemAdventurer == null)
        {
            return;
        }
        
        if (uiItem != null && uiItemAdventurer == null)
        {
            _uiInventory.OnUIItemDrop(this,uiItem);
        }else if (uiItem == null && uiItemAdventurer != null)
        {
            _uiInventory.OnUIItemAdventurerDrop(this,uiItemAdventurer);
        }
    }
    
    public void RemoveUIItem()
    {
        Destroy(_uiItem.gameObject);
        Clear();
    }
}