using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed = 800.0f;
    public Text scoreText;
    private int count = 0;
    public Text winText;
    public GameObject exitRamp;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        if (transform.position.y <= -110)
        {
            resetPlayer();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            resetPlayer();
        }

        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            scoreText.text = "Score: " + count;

            if (count >= 17)
            {
                //winText.gameObject.SetActive(true);
                exitRamp.SetActive(true);
            }

        }
    }

    void resetPlayer()
    {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}