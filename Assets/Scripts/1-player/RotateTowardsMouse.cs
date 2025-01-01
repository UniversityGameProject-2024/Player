using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public float sensitivity = 5f; // Sensitivity of mouse rotation
    public float verticalRotationLimit = 80f; // Limit for up/down rotation

    public float rotationSpeed = 50F;


    private float verticalRotation = 0f; // Track vertical rotation for clamping

    void Update()
    {
        HandleRotationByMouse();
    }

private void HandleRotationByMouse()
{
    // Get the horizontal mouse movement
    float horizontalMouseMovement = Input.GetAxis("Mouse X");

     

    // Only rotate if there's significant mouse movement
    //if (Mathf.Abs(horizontalMouseMovement) < 0.1f) // Add a small threshold to avoid unwanted tiny rotations
    //{
    //    return;
    //}

    // Debug.Log("horizontalMouseMovement: " + horizontalMouseMovement);

    // Calculate the rotation amount based on input and rotation speed
    float rotationAmount = horizontalMouseMovement * rotationSpeed * Time.deltaTime;

    // Apply the rotation around the Y-axis (vertical axis)
    transform.Rotate(0, rotationAmount, 0, Space.Self);

    // Optionally, update the animator if necessary
    //animator.SetBool("isMoving", true);
}


    void RotatePlayer()
    {
        // Get mouse delta
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Horizontal rotation (rotate player around the Y-axis)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (rotate camera or object around the X-axis)
        //verticalRotation -= mouseY;
        //verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

        // Apply the vertical rotation (local rotation to avoid affecting global rotation)
        //Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}