using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowlip : MonoBehaviour, Interface_Interactable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Gathinging Glowlip");
        return true;
    }
}
