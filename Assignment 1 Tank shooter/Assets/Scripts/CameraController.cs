using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject tank;
    [SerializeField]
    private float heightOffset;
    [SerializeField]
    private float distanceOffset;

    public float HeightOffset { get => heightOffset; set => heightOffset = value; }
    public float DistanceOffset { get => distanceOffset; set => distanceOffset = value; }
    public GameObject Tank { get => tank; set => tank = value; }

    void LateUpdate()
    {
        transform.rotation = tank.transform.rotation;
        Vector3 newPosition = tank.transform.position;
        newPosition.y += heightOffset;
        transform.position = newPosition;
        transform.position -= transform.forward * distanceOffset;
    }
}