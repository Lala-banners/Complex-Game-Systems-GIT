using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //public Skybox skybox;
    //[SerializeField] private Camera cam;
    [SerializeField] private float force = 1.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
