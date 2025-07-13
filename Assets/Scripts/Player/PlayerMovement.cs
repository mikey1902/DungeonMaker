using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController pController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool isSprinting = false;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    void Start()
    {
        pController = GetComponent<CharacterController>();
    }

	void Update()
	{
        isGrounded = pController.isGrounded;
	}

	public void InputMove(Vector2 input)
	{
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        pController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        pController.Move(playerVelocity * Time.deltaTime);
	}
    public void InputJump()
	{
        if(isGrounded)
		{
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
		}
	}
    public void InputSprint()
	{
        isSprinting = !isSprinting;

        if (isSprinting)
            speed = 8f;
        else
            speed = 5f;
	}
}
