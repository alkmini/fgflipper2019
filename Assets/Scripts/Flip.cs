using UnityEngine;
using UnityEngine.Assertions;

public class Flip : MonoBehaviour
{
    public float flipperSpeed = 1000f;
    public float reverseMod = 1f;

    [System.NonSerialized] public bool isPressed = false;

    private HingeJoint2D hinge;


    private void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        Assert.IsNotNull(hinge, "Could'nt find the hinge component"); //This will only run in debug mode.
    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            JointMotor2D motor = hinge.motor;

            motor.motorSpeed = reverseMod * flipperSpeed;
            hinge.motor = motor;
        }
        else // if isPressed is not true
        {

            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * -flipperSpeed;
            hinge.motor = motor;
        }

    }
}