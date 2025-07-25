using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI2 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stopDistance = 1f;

    private Rigidbody2D rb;

    public int damage = 5;

    public int enemyHealth = 150;
    int currentHealth;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
        EnemyTakeDamage(10);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position);
        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            Vector2 move = direction.normalized * moveSpeed;
            rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
        }
    }

    public void EnemyTakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        Debug.Log(gameObject.name + " took damage! Current health: " + enemyHealth);

        if (enemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }
}