using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    void Start() => rb = GetComponent<Rigidbody>();

    void FixedUpdate() => rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up")) {
            other.gameObject.SetActive(false);
        }
    }
}
