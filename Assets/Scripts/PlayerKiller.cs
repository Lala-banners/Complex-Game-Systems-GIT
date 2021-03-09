using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;

    IEnumerator Start()
    {
        pointA = transform.position;

        while (true)
        {
            yield return StartCoroutine(MoveObstacle(transform, pointA, pointB, 2.0f));
            yield return StartCoroutine(MoveObstacle(transform, pointB, pointA, 2.0f));
        }
    }

    IEnumerator MoveObstacle(Transform thisT, Vector3 startPos, Vector3 endPos, float time)
    {
        float index = 0.0f;
        float rate = 1.0f / time;

        while (index < 1.0f)
        {
            index += Time.deltaTime * rate;
            thisT.position = Vector3.Lerp(startPos, endPos, index);
            yield return null;
        }
    }

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
