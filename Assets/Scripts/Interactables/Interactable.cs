using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool useEvents;
    public string promptMessage;

    public void BaseInteract()
    {
        if (useEvents)
        {
            gameObject.GetComponent<InteractionEvent>().onInteract.Invoke();
        }
        Interact();
    }
  protected virtual void Interact()
    {

    }
}
