using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private IInteractable _parentInteractable;

    private void Awake()
    {
        _parentInteractable = GetComponentInParent<IInteractable>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if(player == null)
            return;

        Debug.Log("Player entered zone");
        player.SetInteraction(_parentInteractable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        player.ClearInteraction();
    }
}
