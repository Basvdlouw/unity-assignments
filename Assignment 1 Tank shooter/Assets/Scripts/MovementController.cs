using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float turningSpeed;
    [SerializeField]
    private float speed;

    public float TurningSpeed { get => turningSpeed; set => turningSpeed = value; }
    public float Speed { get => speed; set => speed = value; }

    void Start() => rb = GetComponent<Rigidbody>();
    void Update() => movePlayer();

    void movePlayer()
    {
        bool forward = true;
        if (Input.GetAxis("Vertical") == 1)
        {
            Debug.Log("test");
            forward = true;
            moveForward();
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            forward = false;
            moveBackward();
        }
        if (Input.GetAxis("Horizontal") == -1)
        {
            turnLeft(forward);
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            turnRight(forward);
        }
    }
    void moveForward() => transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);

    void moveBackward() => transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);

    void turnLeft(bool forward)
    {
        if (forward)
            transform.Rotate(-Vector3.up * turningSpeed * Time.deltaTime);
        else
            transform.Rotate(-Vector3.down * turningSpeed * Time.deltaTime);

    }
    void turnRight(bool forward)
    {
        if (forward)
            transform.Rotate(Vector3.up * turningSpeed * Time.deltaTime);
        else
            transform.Rotate(Vector3.down * turningSpeed * Time.deltaTime);
    }

}
