using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //Collectables
        if (other.gameObject.tag == "Player")
        {
            UIManager.manager.UpdateScore();
            Destroy(this.gameObject);
        }
    }



}
