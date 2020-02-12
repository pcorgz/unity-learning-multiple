using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBMoveLeft : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;

    private void Update()
    {
        if (FBGameManager.IsRunning)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObstacleTrigger"))
        {
            Destroy(gameObject);
        }
    }
}
