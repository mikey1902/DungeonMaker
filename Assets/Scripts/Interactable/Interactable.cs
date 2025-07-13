using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public bool useEvents;
    public string msgPrompt;

	public void BaseInteract()
	{
		if(useEvents)
		{
			GetComponent<Event_Interaction>().OnInteract.Invoke();
		}
		Interact();
	}
    protected virtual void Interact()
	{

	}
}
