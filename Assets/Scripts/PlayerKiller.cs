using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other);
            print("Player Dead");
        }
    }
}
