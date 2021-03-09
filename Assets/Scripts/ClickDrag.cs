using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    [SerializeField] private float forceAmount = 500f;

    Rigidbody dragObject;
    Vector3 offset;

    Vector3 originalPosition;
    float selectionDistance;

    private void Update()
    {
        #region Drag Bot
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                selectionDistance = Vector3.Distance(ray.origin, hit.point);

                dragObject = hit.rigidbody;
                offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                        Input.mousePosition.y,
                                                        selectionDistance));
                originalPosition = hit.collider.transform.position;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        #region Drag Bot 2
        if (dragObject)
        {
            Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3
                                                    (Input.mousePosition.x,
                                                    Input.mousePosition.y,
                                                    selectionDistance)) - originalPosition;

            dragObject.velocity = (originalPosition + mousePositionOffset - dragObject.transform.position)
                                    * forceAmount * Time.deltaTime;
        }
        #endregion
    }
}
