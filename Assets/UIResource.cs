using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResource : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private Image _backgroundImage;
    

    public void Initialize(ResourceDefinition resourceDefinition, int amount = 0)
    {

        _backgroundImage.sprite = resourceDefinition.Icon;
        _amountText.text = amount.ToString();
    }
}
