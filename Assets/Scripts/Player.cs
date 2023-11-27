using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; // The player's maximum health
    public int currentHealth; // The player's current health

    void Start()
    {
        currentHealth = maxHealth; // Set the current health to the maximum health at the start of the game
    }

    public void TakeDamage(int damage)
    {
        // print("Took damage!");
        currentHealth -= damage; // Decrease the current health by the damage amount

        // Check if the player's health has fallen below zero
        if (currentHealth <= 0)
        {
            Die(); // Call the Die function
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Increase the current health by the heal amount

        // Check if the player's health has gone above the maximum health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Set the current health to the maximum health
        }
    }

    void Die()
    {
        // Add code here to handle the player's death
        print("Died!");
        // GetComponent<PlayerMove>().enabled = false;

        // Play the death animation
        // GetComponent<Animator>().SetTrigger("Die");

        // Restart the level after a delay
        // Invoke("RestartLevel", 2f);
        
    }
    void RestartLevel()
{
    // Load the current level
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}