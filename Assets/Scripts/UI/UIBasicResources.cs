using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBasicResources : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private UIResource _uiResourcePrefab2;
    [SerializeField] private ResourceDefinition[] _basicResourceDefinitions;
    
    private ResourceBag _resourceBag;
    private Dictionary<ResourceDefinition,UIResource> _uiResources =new Dictionary<ResourceDefinition, UIResource>();

    private void Start()
    {
        _resourceBag = FindObjectOfType<Player>().ResourceBag;
        CreateUIResources();
        _resourceBag.OnResourcesChanged += RefreshAllUIBasicResources;
    }

    private void OnDestroy()
    {
        _resourceBag.OnResourcesChanged -= RefreshAllUIBasicResources;

    }

    private void CreateUIResources()
    {
        foreach (var basicResource in _basicResourceDefinitions)
        {
            var uiResource = Instantiate(_uiResourcePrefab2, _content);
            var resourceAmount = _resourceBag.CurrentResources[basicResource.Type].Amount;
            uiResource.Initialize(basicResource,resourceAmount);
            _uiResources.Add(basicResource,uiResource);
        }
    }

    private void RefreshAllUIBasicResources()
    {
        foreach (var uiResource in _uiResources)
        {
            var newResourceAmount = _resourceBag.CurrentResources[uiResource.Key.Type].Amount;
            uiResource.Value.Initialize(uiResource.Key,newResourceAmount);
        }
    }
}
