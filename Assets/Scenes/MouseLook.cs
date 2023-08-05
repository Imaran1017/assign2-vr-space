using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    public float minimumY = -90f;
    public float maximumY = 90f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        // Calculate the vertical rotation
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        // Apply the vertical rotation to the camera
        transform.localEulerAngles = new Vector3(rotationY, 0f, 0f);

        // Calculate the horizontal rotation
        rotationX += mouseX;

        // Apply the horizontal rotation to the player object (or camera parent, if necessary)
        transform.parent.transform.localEulerAngles = new Vector3(0f, rotationX, 0f);
    }
}
