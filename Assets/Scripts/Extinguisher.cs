using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    // Start is called before the first frame update
    // public enum FireType { wood, electrical, battery, chemical }

    public Fire.FireType fireType;
    public GameObject wrongSign;

    private bool hasPlayedRightSound = false; // Add this line
    public AudioSource rightSound;
    public AudioSource wrongSound;
    public AudioClip rightClip;

    public AudioClip wrongClip;
    void Start()
    {
        wrongSign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        wrongSound.volume = 0.2f;
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f))
        {
            if(hit.collider.TryGetComponent<Fire>(out Fire fire))

            {
                if(fire.fireType == fireType)
                {
                    if (!hasPlayedRightSound) // Add this line
                    {
                        rightSound.PlayOneShot(rightClip);
                        hasPlayedRightSound = true; // Add this line
                    }
                    fire.TryExtinguish(0.1f);
                    
                }
                else{
                    wrongSound.PlayOneShot(wrongClip);
                    wrongSign.SetActive(true);
                    print("Wrong fire type");
                }
            }
        }
    }
}
