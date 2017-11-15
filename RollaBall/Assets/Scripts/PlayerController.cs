using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int count;
    public Text countText;

    public AudioSource pickupSFX;

    public float speed;
    private Rigidbody rb;
    private int iThrust = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        if (iThrust < 2)
        {
            rb.AddForce(movement * 20 * speed);
            iThrust++;
        }
        else
        {
            rb.AddForce(movement * speed);
            iThrust = 1;
        }
        


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            //AudioSource audio = other.GetComponent<AudioSource>();
            //audio.Play();
            pickupSFX.Play();
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
