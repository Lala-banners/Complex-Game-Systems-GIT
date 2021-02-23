using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public TMP_Text scoreText;

    List<Joint> joints; //List of joints in the character

    [SerializeField]
    private float minForceForScore = 1000; //Minimum amount of force needed to get a score

    [SerializeField]
    private float scoreMultiplier;

    public float currentScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        joints = new List<Joint>(GetComponentsInChildren<Joint>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float appliedForce = 0f;

        foreach (Joint joint in joints)
        {
            appliedForce += joint.currentForce.magnitude;
        }

        if (appliedForce > minForceForScore) //If applied force is greater than the min force allowed for scoring
        {
            currentScore += (appliedForce * scoreMultiplier * Time.deltaTime); //Current score plus/equal to applied force
            scoreText.text = "Score: " + (int)currentScore; //Update the score text
        }

        Debug.Log(appliedForce);
    }
}
