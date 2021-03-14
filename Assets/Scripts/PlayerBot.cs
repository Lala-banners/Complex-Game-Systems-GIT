using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "End Platform")
        {
            UIManager.manager.WinLevel();
        }
    }
}
