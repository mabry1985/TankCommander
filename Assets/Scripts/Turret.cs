using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotationSpeed = 100.0F;
    public Joystick joystick;

    void Update()
    {
        float rotation = joystick.Horizontal * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
