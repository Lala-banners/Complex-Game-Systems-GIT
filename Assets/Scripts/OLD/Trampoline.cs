using UnityEngine;
using TMPro;

public class Trampoline : MonoBehaviour
{
    public bool isPortal; //for character to know its hit a portal
    [SerializeField] private float bounceMultiplier;
    [SerializeField] private float currentScore;
    public TMP_Text scoreCount;
    [SerializeField] private Hips hips;

    private void Start()
    {
        bounceMultiplier = 5000f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If player collides with platform and y velocity is 0 then make player bounce upwards
        if (collision.gameObject.tag == "Player")
        {
            hips.hipsRB.AddForce(Vector3.up * bounceMultiplier);
            DestroyTrampoline();

            
        }
    }

    public void DestroyTrampoline()
    {
        Destroy(gameObject, 0.5f);
    }
}
