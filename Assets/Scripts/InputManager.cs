using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions playerInput;
    private InputSystem_Actions.GroundActions groundInput;

    void Awake()
    {
        playerInput = new InputSystem_Actions();
        groundInput = playerInput.Ground;
    }

	private void OnEnable()
	{
        groundInput.Enable();
	}
    private void OnDisable()
    {
        groundInput.Disable();
    }
}
