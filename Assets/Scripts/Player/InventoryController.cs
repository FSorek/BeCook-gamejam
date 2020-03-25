using Items;

public class InventoryController
{
    private Inventory _playerInventory;

    public InventoryController(Inventory inventory)
    {
        _playerInventory = inventory;
    }

    public void EquipItem(AdventurerInventory adventurerInventory, SlotType slotType, Item item)
    {
        var goodType = GoodType(adventurerInventory, slotType, item);
        var adventurerSlotIsEmpty = AdventurerSlotIsEmpty(adventurerInventory, slotType);
        var itemIsInventory = ItemIsInInventory(item);
        
        if (!goodType||!adventurerSlotIsEmpty||!itemIsInventory)
            return;

        _playerInventory.RemoveItem(item);
        adventurerInventory.EquipItem(slotType, item);
    }

    public void UnEquipItem(AdventurerInventory adventurerInventory, Item item)
    {
        bool itemIsEquip = adventurerInventory.ContainItem(item);
        bool inventoryIsFull = _playerInventory.IsFull;
        bool itemIsInInventory = _playerInventory.ContainItem(item);
        
        
        if (itemIsEquip && inventoryIsFull==false&& itemIsInInventory==false)
        {
            adventurerInventory.UnEquipItem(item);
            _playerInventory.AddItem(item);
        }
    }

    public void SwitchItemInventoryToAdventurer(AdventurerInventory adventurerInventory, SlotType slotType, Item itemInInventory)
    {
        var goodType = GoodType(adventurerInventory, slotType, itemInInventory);
        var adventurerSlotIsEmpty = AdventurerSlotIsEmpty(adventurerInventory, slotType);
        var itemIsInInventory = ItemIsInInventory(itemInInventory);
        
        
        if(!goodType || adventurerSlotIsEmpty ||!itemIsInInventory)
            return;
        
        Item itemAdventurer = adventurerInventory.GetItem(slotType);
        if(ItemIsInInventory(itemAdventurer))
            return;
        
        _playerInventory.RemoveItem(itemInInventory);
        adventurerInventory.UnEquipItem(itemAdventurer);

        _playerInventory.AddItem(itemAdventurer);
        adventurerInventory.EquipItem(slotType, itemInInventory);
    }

    private bool ItemIsInInventory(Item item)
    {
        return _playerInventory.ContainItem(item);
    }

    private bool AdventurerSlotIsEmpty(AdventurerInventory adventurerInventory, SlotType slotType)
    {
        return adventurerInventory.SlotIsEmpty(slotType);
    }

    private bool GoodType(AdventurerInventory adventurerInventory, SlotType slotType, Item item)
    {
        return adventurerInventory.GetItemType(slotType) == item.ItemType;
    }
}