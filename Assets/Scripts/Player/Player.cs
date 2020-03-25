using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private RecipeDefinition[] _recipeDefinitions;
    [SerializeField] private ResourceDefinition[] _resourceDefinitions;
    [SerializeField] private float _speed = 2f;
    
    private IInteractable _availableInteraction;
    public Inventory Inventory { get; private set; }
    public ResourceBag ResourceBag { get; private set; }
    public RecipeBook RecipeBook { get; private set; }

    public InventoryController InventoryController { get; private set; }
    
    private void Awake()
    {
        Inventory = new Inventory();
        ResourceBag = new ResourceBag(_resourceDefinitions);
        RecipeBook = new RecipeBook(_recipeDefinitions);
        InventoryController = new InventoryController(Inventory);
    }

    private void Update()
    {
        Move();
        
        if(_availableInteraction != null && Input.GetKeyDown(KeyCode.E))
            _availableInteraction.Use();
    }

    private void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        transform.position += Time.deltaTime * _speed * new Vector3(horizontal, vertical).normalized;
    }

    public void SetInteraction(IInteractable interactable)
    {
        _availableInteraction = interactable;
    }

    public void ClearInteraction()
    {
        _availableInteraction = null;
    }
}
