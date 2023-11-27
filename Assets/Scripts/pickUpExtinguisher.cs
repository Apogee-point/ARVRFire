using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpExtinguisher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickUpText;

    private Vector3 originalPosition;
    public AudioSource pickUpSound;

    public AudioClip pickUpClip;
    public GameObject extinguisher;
    
    public Fire.FireType fireType;

    void Start()
    {
        originalPosition = this.gameObject.transform.position;
        extinguisher.SetActive(false);
        pickUpText.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && extinguisher.activeSelf)
        {
            extinguisher.SetActive(false);
            gameObject.transform.position = originalPosition;
            gameObject.SetActive(true);
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Extinguisher picked up");
                pickUpSound.PlayOneShot(pickUpClip);
                Transform particle = extinguisher.transform.GetChild(0);
                particle.GetComponent<Extinguisher>().fireType = fireType;
                extinguisher.SetActive(true);

                originalPosition = extinguisher.transform.position;
                this.gameObject.SetActive(false);
                pickUpText.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
}
