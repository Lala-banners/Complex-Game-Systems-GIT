using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Transform destination; //to shoot player into space

    public bool isPortal; //for character to know its hit a portal

    private void Start()
    {
        if (isPortal == true)
        {
            destination = GameObject.FindGameObjectWithTag("Portal").GetComponent<Transform>();
        }
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        //If player has collided with the portal, make player's position to the destination
        collision.transform.position = new Vector2(destination.position.x, destination.position.y);
        SceneManager.LoadScene("Level1");

        print("Unity-Chan is in space!");
    }



}
