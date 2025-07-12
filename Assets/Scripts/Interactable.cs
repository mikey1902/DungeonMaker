using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string msgPrompt;
	public void BaseInteract()
	{
		Interact();
	}
    protected virtual void Interact()
	{

	}
}
