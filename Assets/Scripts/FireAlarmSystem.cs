using UnityEngine;

public class FireAlarmSystem : MonoBehaviour
{
    public hoseBegin waterSprayer; // The water sprayer
    public KeyCode fireSafetyButton = KeyCode.L; // The fire safety button

    void Update()
    {
        if (Input.GetKeyDown(fireSafetyButton))
        {
            waterSprayer.turnOnHose();
        }
    }
}