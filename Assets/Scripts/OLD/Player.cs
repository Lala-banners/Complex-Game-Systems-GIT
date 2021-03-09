using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] private float force = 1.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


}
