using System.Collections;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public float patrolSpeed = 3f; // Adjust the speed as needed
    public float idleTime = 2f; // Adjust the time the character stays idle

    private Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Start the patrol routine
        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            // Move the character to the right
            MoveCharacter(patrolSpeed);

            // Wait for 2 seconds
            yield return new WaitForSeconds(2f);

            // Stop the character
            MoveCharacter(0f);

            // Switch to idle animation
            animator.SetBool("IsRunning", false);

            // Wait for 2 seconds
            yield return new WaitForSeconds(idleTime);

            // Flip the character to the left
            Flip();

            // Move the character to the left
            MoveCharacter(-patrolSpeed);

            // Wait for 2 seconds
            yield return new WaitForSeconds(2f);

            // Stop the character
            MoveCharacter(0f);

            // Switch to idle animation
            animator.SetBool("IsRunning", false);

            // Wait for 2 seconds
            yield return new WaitForSeconds(idleTime);

            // Flip the character back to the right
            Flip();
        }
    }

    void MoveCharacter(float speed)
    {
        // Move the character horizontally
        rb.velocity = new Vector2(isFacingRight ? speed : -speed, rb.velocity.y);

        // Flip the character when changing direction
        if ((isFacingRight && rb.velocity.x < 0) || (!isFacingRight && rb.velocity.x > 0))
        {
            Flip();
        }

        // Transition between run and idle animations
        animator.SetBool("IsRunning", Mathf.Abs(rb.velocity.x) > 0.1f);
    }

    void Flip()
    {
        // Flip the character horizontally
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}