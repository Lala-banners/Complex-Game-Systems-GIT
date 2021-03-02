using UnityEngine;
using TMPro;

public class Trampoline : MonoBehaviour
{
    public bool isPortal; //for character to know its hit a portal
    [SerializeField] private float bounceMultiplier;
    [SerializeField] private float currentScore;
    public TMP_Text scoreCount;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If player collides with platform and y velocity is 0 then make player bounce upwards
        if (collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(Vector3.up * 50000f); //propel player upwards
            
            //Update score
            if (collision.rigidbody.velocity.y > 0 && transform.position.y > currentScore)
            {
                currentScore = transform.position.y;
            }
        }
    }

    public void SetScore()
    {
        if (rb.velocity.y > 0 && transform.position.y > currentScore)
        {
            currentScore = transform.position.y;
        }
        UpdateScore(currentScore);
    }

    public void UpdateScore(float currentScore)
    {
        //Update score text to be current score
        scoreCount.text = "Score: " + Mathf.Round(currentScore).ToString();
    }
}
