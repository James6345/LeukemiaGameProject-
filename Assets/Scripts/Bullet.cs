using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Auto-destroy after time

    private void Start()
    {
        Destroy(gameObject, lifetime); // Destroy bullet after lifetime expires
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
