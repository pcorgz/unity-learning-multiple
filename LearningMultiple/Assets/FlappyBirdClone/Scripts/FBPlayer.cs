using System.Collections;
using UnityEngine;

public class FBPlayer : MonoBehaviour
{
    [SerializeField]
    private float upVelocity = 0f;

    private Rigidbody2D rb;
    private bool goingUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        goingUp = Input.GetMouseButton(0);
    }

    private void FixedUpdate()
    {
        if (FBGameManager.IsRunning && goingUp)
        {
            rb.velocity = Vector2.up * upVelocity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            FBGameManager.gameState = GameState.Stopped;
        }
        if (collision.CompareTag("Scorer"))
        {
            FBGameManager.score++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            FBGameManager.gameState = GameState.Stopped;
            // TODO: Animation Game Over screen

            StartCoroutine(RestartGame());
        }
    }

    private IEnumerator RestartGame()
    {
        // TODO remove this method; use button action for restart
        yield return new WaitForSeconds(2f);
        FBGameManager.Reset();
    }
}
