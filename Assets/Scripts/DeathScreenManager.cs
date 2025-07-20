using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject deathScreenUI; // Assign in Inspector
   /* private PlayerHealth playerHealth; // Reference to your health script

    private void Start()
    {
        // Find the player health component (adjust if your setup is different)
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.OnDeath += ShowDeathScreen;
        }

        // Ensure death screen is hidden at start
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }
   */

    private void ShowDeathScreen()
    {
        // Show the death screen
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    // Button functions
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene("MainMenu"); // Change to your menu scene name
    }

    /* private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDeath -= ShowDeathScreen;
        }
    }
    */
}
