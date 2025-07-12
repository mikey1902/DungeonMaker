using UnityEngine;

public class Door : Interactable
{
	[SerializeField] private GameObject door;
	private bool isDoorOpen;
	protected override void Interact()
	{
		isDoorOpen = !isDoorOpen;
		door.GetComponent<Animator>().SetBool("IsOpen", isDoorOpen);
	}
}
