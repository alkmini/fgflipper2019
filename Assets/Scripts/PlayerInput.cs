using UnityEngine;
using UnityEngine.Assertions;

public class PlayerInput : MonoBehaviour
{
    private Camera playerCamera; // Default value null 
    private Flip leftFlipper;
    private Flip rightFlipper;

    private const string leftFlipperName = "LeftFlipper";
    private const string rightFlipperName = "RightFlipper";

    #region Unity methods


    private void Awake()
    {
        playerCamera = Camera.main;// Camera.main uses find object of tag internally
        leftFlipper = GetFlipper(leftFlipperName);
        Assert.IsNotNull(leftFlipper, "Child: " + leftFlipperName + "was not found");

        rightFlipper = GetFlipper(rightFlipperName);
        Assert.IsNotNull(rightFlipper, "Child: " + rightFlipperName + "was not found");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        float xPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        leftFlipper.isPressed = Input.GetButton(leftFlipperName);

        rightFlipper.isPressed = Input.GetButton(rightFlipperName);
    }
    #endregion Unity methods

    private Flip GetFlipper(string flipperName)
    {

        return transform.Find(flipperName)?.GetComponent<Flip>();

    }
}