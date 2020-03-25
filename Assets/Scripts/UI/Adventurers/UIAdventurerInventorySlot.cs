using System;
using Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAdventurerInventorySlot : MonoBehaviour,IDropHandler
{
    [SerializeField] private UIItemAdventurer _uiItemPrefab;
    [SerializeField] private RectTransform _uiItemParent;
    [SerializeField]private UIAdventurerInventory _uiAdventurerInventory;


    public UIItemAdventurer UiItemAdventurer { get; private set; }
    public Item ItemInSlot => UiItemAdventurer.Item;

    public RectTransform RectTransform { get; private set; }
    public bool IsEmpty => UiItemAdventurer == null;
    
    public SlotType SlotTypeD { get; set; }

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
    
    
    public void OnDrop(PointerEventData eventData)
    {
        var uiItem = eventData.pointerDrag.GetComponent<UIItem>();

        if (uiItem == null)
            return;

        _uiAdventurerInventory.OnUIItemDrop(this,uiItem);
    }

    private void Clear()
    {
        UiItemAdventurer = null;
    }
    
    public void CreateUIItem(Item item)
    {
        var uiItem=Instantiate(_uiItemPrefab, _uiItemParent);
        uiItem.Initialize(item,this,_uiAdventurerInventory.AdventurerInventory);
        UiItemAdventurer = uiItem;
    }
    public void RemoveUIItem()
    {
        Destroy(UiItemAdventurer.gameObject);
        Clear();
    }
}