using System;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _itemInfoPanel;
    [SerializeField] private TextMeshProUGUI _textItemInfo;
    
    private Item _item;
    
    public bool IsEmpty => _item == null;
    

    public void SetItemAndRefreshUI(Item item)
    {
        _item = item;
        _image.sprite = item.Sprite;
        RefreshItemInfoPanel();
    }

    private void RefreshItemInfoPanel()
    {
        var info = $"name :  { _item.Name } \n durability : {_item.Durability}";
        _textItemInfo.text = info;
    }

    public void Clear()
    {
        _item = null;
    }

    public void EnableItemInfoPanel()
    {
        if (_item == null)
            return;
        _itemInfoPanel.SetActive(true);
    }
    
    public void DisableItemInfoPanel()
    {
        if (_item == null)
            return;
        _itemInfoPanel.SetActive(false);
    }
}