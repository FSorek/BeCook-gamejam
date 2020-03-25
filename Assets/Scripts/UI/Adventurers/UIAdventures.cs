using UnityEngine;
using UnityEngine.UI;

public class UIAdventures : MonoBehaviour
{
    [SerializeField] private UIAdventurer _uiAdventurerPrefab;
    [SerializeField] private UIAdventurerInventory _uiAdventurerInventoryPrefab;
    [SerializeField] private RectTransform _uiAdventurerParent;
    [SerializeField] private RectTransform _uiAdventurerInventoryParent;

    private UIAdventurerInventory _currentActiveInventory;

    private void Start()
    {
        var adventurers = FindObjectOfType<Adventurers>();
        CreateUIAdventurers(adventurers);
    }

    private void CreateUIAdventurers(Adventurers adventurers)
    {
        var adventurersList = adventurers.AdventurersList;

        foreach (var adventurer in adventurersList)
        {
            var uiAdventurer = Instantiate(_uiAdventurerPrefab, _uiAdventurerParent);
            var uiAdventurerInventory = Instantiate(_uiAdventurerInventoryPrefab, _uiAdventurerInventoryParent);
            
            uiAdventurer.Initialize(adventurer);
            uiAdventurerInventory.Initialize(adventurer);

            uiAdventurer.gameObject.name = adventurer.Name;
            uiAdventurerInventory.gameObject.name = adventurer.Name + " Inventory";
            
            uiAdventurer.GetComponent<Button>().onClick.AddListener((() => ChangeActiveInventory(uiAdventurerInventory)));
        }
    }

    private void ChangeActiveInventory(UIAdventurerInventory newActiveInventory)
    {
        if (_currentActiveInventory != null)
        {
            _currentActiveInventory.gameObject.SetActive(false);
        }
        
        newActiveInventory.gameObject.SetActive(true);
        _currentActiveInventory = newActiveInventory;
    }
}