using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions playerInput;
    public InputSystem_Actions.GroundActions groundInput;

    private PlayerMovement pMovement;
    private PlayerLook pLook;

    void Awake()
    {
        playerInput = new InputSystem_Actions();
        groundInput = playerInput.Ground;
        pMovement = GetComponent<PlayerMovement>();
        pLook = GetComponent<PlayerLook>();
        groundInput.Jump.performed += ctx => pMovement.InputJump();
    }

	void FixedUpdate()
	{
        pMovement.InputMove(groundInput.Move.ReadValue<Vector2>());
	}
	private void LateUpdate()
	{
        pLook.InputLook(groundInput.Look.ReadValue<Vector2>());
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
