using UnityEditor;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
	public override void OnInspectorGUI()
	{
		Interactable interactable = (Interactable)target;
		if (target.GetType() == typeof(UsingEventInteractable))
		{
			interactable.msgPrompt = EditorGUILayout.TextField("Prompt Message", interactable.msgPrompt);

			if (interactable.GetComponent<Event_Interaction>() == null)
			{
				interactable.useEvents = true;
				interactable.gameObject.AddComponent<Event_Interaction>();
			}
		}

		else
		{
			base.OnInspectorGUI();

			if (interactable.useEvents)
			{
				if (interactable.GetComponent<Event_Interaction>() == null)
				{
					interactable.gameObject.AddComponent<Event_Interaction>();
				}
			}
			else
			{
				if (interactable.GetComponent<Event_Interaction>() != null)
				{
					DestroyImmediate(interactable.GetComponent<Event_Interaction>());
				}
			}
		}
	}
}
