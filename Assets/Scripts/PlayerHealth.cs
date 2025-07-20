using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }
    void PlayerDie()
    {
        Debug.Log(gameObject.name + " died!");
        Destroy(gameObject);
    }
}