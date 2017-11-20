using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 moveCoordinatesScreen;
    public Vector3 moveCoordinatesWorld;
    public Vector3 ChinPosition;
    public Rigidbody rb;
    private Vector3 destination;
    private Vector3 pos;

    Animator PlayerAni;

    private Vector3 buffer = new Vector3(3, 3, 0);

    // Use this for initialization
    void Start ()
    {
        PlayerAni = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ///if (Input.GetButtonDown("Fire1"))
        pos = transform.position;
        PlayerAni.SetBool("IsWalking", false);

        //transform.Rotate(new Vector3(0, 0, 1));

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Click registered"); 
            //Debug.Log(Input.mousePosition);


            //Teleport player to spot:
            //vector3 pos = input.mouseposition;
            //pos = camera.main.screentoworldpoint(pos);
            //pos.z = 0;
            //debug.log(pos);
            //rb.moveposition(pos);

            //Move player to spot:
            destination = Input.mousePosition;
            destination = Camera.main.ScreenToWorldPoint(destination);
            destination.z = 0;

            Debug.Log(destination);

            
        }

        if (pos != destination)
        {
            Vector3 travel = (destination - pos)/50;
            rb.MovePosition(pos + travel);
        }
        
        if (Vector3.Magnitude(pos-destination) > .5)
        {
            PlayerAni.SetBool("IsWalking", true);
        }


    }
}
