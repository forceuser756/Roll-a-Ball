using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text pickupText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int pickup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        pickup = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick Up"))
       {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
       }
       if (other.gameObject.CompareTag("Red Pick Up"))
        {
            other.gameObject.SetActive(false);
            pickup = pickup + 1;
            count = count - 1;
            SetCountText();
            SetCountText2();
        }
        if (GameObject.FindGameObjectsWithTag("Pick Up").Length == 0)
        {
            winText.text = "You Finished with a score of: " + count.ToString();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
    }
    void SetCountText2 ()
    {
        pickupText.text = "Pickups: " + count.ToString();
    }
}
