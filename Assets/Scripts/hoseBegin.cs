using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoseBegin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hose;
    
    public AudioSource extinguisherSound;

    public AudioClip extinguisherClip;

    public void turnOnHose()
    {
       if(Input.GetMouseButtonDown(0))
        {
            extinguisherSound.PlayOneShot(extinguisherClip);
            hose.SetActive(true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            hose.SetActive(false);
        }
    }

    void Start()
    {
        hose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        turnOnHose();
    }

}
