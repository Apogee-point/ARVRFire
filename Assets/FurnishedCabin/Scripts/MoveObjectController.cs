using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public KeyCode openDoorKey = KeyCode.E; // The key to open the door
    public float openAngle = 90f; // The rotation angle when the door is open
    public float openSpeed = 2f; // The speed at which the door opens

    public float pickUpRange = 3f;
    private bool isOpen = false; // Whether the door is currently open
    private bool isOpening = false;

    void Update()
    {
        if (Input.GetKeyDown(openDoorKey) && !isOpening)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    if (isOpen)
                    {
                        StartCoroutine(CloseDoor());
                    }
                    else
                    {
                        StartCoroutine(OpenDoor());
                    }
                }
            }
        }
    }
    IEnumerator OpenDoor()
    {
        isOpening = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);

        float t = 0;
        while (t < openSpeed)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / openSpeed);
            yield return null;
        }

        isOpen = true;
        isOpening = false;
    }

    IEnumerator CloseDoor()
    {
        isOpening = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - openAngle, transform.eulerAngles.z);

        float t = 0;
        while (t < openSpeed)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / openSpeed);
            yield return null;
        }

        isOpen = false;
        isOpening = false;
    }
}