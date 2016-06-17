using UnityEngine;
using System.Collections;

public class ElevatorMover : MonoBehaviour{

    public GameObject elevator;
    private bool elevatorMoving = false;
    public GameObject frontWall;
    public GameObject player;

    void FixedUpdate()
    {
        if (elevatorMoving == true)
        {
            if (elevator.transform.position.y <= 9.9f)
            {
                elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y + 0.1f, elevator.transform.position.z);
            }
            else
            {
                elevatorMoving = false;
                frontWall.SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            elevatorMoving = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            player.SendMessage("elevatorCheckpoint");
        }
    }

}
