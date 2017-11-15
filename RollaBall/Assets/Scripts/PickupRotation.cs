using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{
    public float RotateSpeed;
    private Vector3 RotateVector;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 RotateVector = new Vector3(RotateSpeed*150, RotateSpeed*150, -RotateSpeed*100);
        transform.Rotate(RotateVector * Time.deltaTime, Space.World);
    }
}