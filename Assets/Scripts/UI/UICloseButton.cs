using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UICloseButton : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToClose;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener((() => _gameObjectToClose.SetActive(false)));
    }
}
