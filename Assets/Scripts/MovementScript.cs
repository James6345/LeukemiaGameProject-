using UnityEngine;

public class PlayerMovementEnhanced : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private KeyCode dashKey = KeyCode.Space;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 currentVelocity;

    private bool isDashing;
    private float dashTimer;
    private float dashCooldownTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize diagonal movement
        if (moveInput.magnitude > 1f)
        {
            moveInput.Normalize();
        }

        // Handle dash input
        if (Input.GetKeyDown(dashKey) && dashCooldownTimer <= 0 && moveInput.magnitude > 0.1f)
        {
            StartDash();
        }

        // Update timers
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                EndDash();
            }
        }

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            // During dash, maintain dash velocity
            rb.velocity = moveInput.normalized * dashSpeed;
        }
        else
        {
            // Normal movement with acceleration/deceleration
            Vector2 targetVelocity = moveInput * moveSpeed;
            currentVelocity = Vector2.MoveTowards(
                currentVelocity,
                targetVelocity,
                (targetVelocity.magnitude > 0 ? acceleration : deceleration) * Time.fixedDeltaTime
            );
            rb.velocity = currentVelocity;
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        dashCooldownTimer = dashCooldown;
    }

    private void EndDash()
    {
        isDashing = false;
        currentVelocity = moveInput * moveSpeed; // Smooth transition from dash
    }
}