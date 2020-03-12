﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResource : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private Image _backgroundImage;
    
    [SerializeField] private Sprite _whiteSprite;
    [SerializeField] private Sprite _greenSprite;

    public void Initialize(ResourceType type, int amount = 0)
    {
        switch (type)
        {
            case ResourceType.White:
                _backgroundImage.sprite = _whiteSprite;
                break;
            case ResourceType.Green:
                _backgroundImage.sprite = _greenSprite;
                break;
        }

        _amountText.text = amount.ToString();
    }
}
