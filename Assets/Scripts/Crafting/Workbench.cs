using System;
using UnityEngine;

public class Workbench : MonoBehaviour, IInteractable
{
    public void Use()
    {
        Debug.Log($"Used {gameObject.name}.");
    }
}