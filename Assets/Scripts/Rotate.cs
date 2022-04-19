using UnityEngine;

public class Rotate : MonoBehaviour
{
    // public Variable that determines the planets rotation speed
    public float rotationSpeed = 0.1f;

    // Update called once per frame rotates the planets respectively according to their rotation speed.
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}