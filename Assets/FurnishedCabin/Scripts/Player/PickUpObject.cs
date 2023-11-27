using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public float pickUpRange = 2f;
    private GameObject carriedObject = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedObject == null)
            {
                // Try to pick up an object
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange))
                {
                    // Check if the hit object has the "Pickup" tag
                    print(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.CompareTag("Pickup"))
                    {
                        carriedObject = hit.collider.gameObject;
                        carriedObject.transform.SetParent(transform);
                    }
                }
            }
            else
            {
                carriedObject.transform.SetParent(null);
                carriedObject = null;
            }
        }
    }
}