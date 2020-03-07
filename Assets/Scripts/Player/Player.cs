using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private IInteractable _availableInteraction;

    private void Update()
    {
        Move();
        
        if(_availableInteraction != null && Input.GetKeyDown(KeyCode.E))
            _availableInteraction.Use();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.position += Time.deltaTime * _speed * new Vector3(horizontal, vertical);
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
