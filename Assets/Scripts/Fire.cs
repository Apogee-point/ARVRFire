using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fire : MonoBehaviour
{

    public enum FireType { wood,electrical,battery,chemical }
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;

    public float damagePerSecond = 10f;
    public float GetIntensity() => currentIntensity;

    public FireType fireType;

    public ParticleSystem steam;

    public float steamDuration = 5f;

    public GameObject correctSign;

    private float[] startIntensities = new float[0];
    float nextRegenTime = 0;
    [SerializeField] private float regenDelay = 2.0f;
    [SerializeField] private float regenRate = .2f;
    
    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    private bool isLit = true;

    private void OnTriggerStay(Collider other)
    {
        // Check if the other GameObject has a Player script
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // Reduce the player's health
            player.TakeDamage(Mathf.RoundToInt(damagePerSecond * Time.deltaTime));
        }
    }

    private void Start()
    {
        correctSign.SetActive(false);
        startIntensities = new float[fireParticleSystems.Length];

        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
    }

   
    IEnumerator ShowAndHide(GameObject gameObject, float delay)
    {
        correctSign.SetActive(true);
        yield return new WaitForSeconds(delay);
        correctSign.SetActive(false);
    }

    private void Update()
    {
        if (isLit && currentIntensity < 1.0f)         
            Regenerate();          
    }

    private void Regenerate() 
    {
        if (Time.time < nextRegenTime)
            return;

        currentIntensity += regenRate * Time.deltaTime;
        ChangeIntensity();
    }

    public bool TryExtinguish(float amount) 
    {
        print("Trying to extinguish the fire");
        nextRegenTime = Time.time + regenDelay;

        currentIntensity -= amount;

        ChangeIntensity();

        if (currentIntensity <= 0) 
        {
            Die();
            StartCoroutine(ShowAndHide(correctSign, 5)); 
            print("Fire Extinguished");
            return true;
        }

        

        return false; //fire is still lit
    }

    private void Die() 
    {
        isLit = false;
        enabled = false;
        // steam.Play();
        // StartCoroutine(StopSteamAfterDelay(steamDuration));
    }

    IEnumerator StopSteamAfterDelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        steam.Stop();
    }
    private void ChangeIntensity() 
    {
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}