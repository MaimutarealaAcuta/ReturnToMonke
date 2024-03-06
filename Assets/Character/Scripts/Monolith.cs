using UnityEngine;

public class Monolith : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Get your hand off me!");
    }
}
