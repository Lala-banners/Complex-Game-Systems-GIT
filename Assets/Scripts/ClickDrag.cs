using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    public Transform dragObject;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                dragObject = hit.transform;
                //Gives direction to ray from click
                offset = hit.transform.position - ray.origin;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }

        if (dragObject)
        {
            dragObject.position = new Vector3(ray.origin.x + offset.x, dragObject.position.y, ray.origin.z + offset.z);
        }
    }

}
