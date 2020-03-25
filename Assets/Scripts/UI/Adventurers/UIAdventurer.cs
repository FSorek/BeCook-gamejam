using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIAdventurer : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Adventurer _adventurer;
    
    public void Initialize(Adventurer adventurer)
    {
        _adventurer = adventurer;
        _image.sprite = _adventurer.Sprite;
    }


}