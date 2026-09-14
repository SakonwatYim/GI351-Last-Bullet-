using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 20f;
    private CharacterController CC;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float Gravity = -10f;

    public Animator camAnim;
    private bool isWalking;

     void Start()
    {
        CC = GetComponent<CharacterController>();
    }

     void Update()
    {
        GetInput();
        MovePlayer();
        CheckHeadBob();

        camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * playerSpeed) + (Vector3.up * Gravity);
    }

    void MovePlayer()
    {
        CC.Move(movementVector * Time.deltaTime);
    }

    void CheckHeadBob()
    {
        if (CC.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}