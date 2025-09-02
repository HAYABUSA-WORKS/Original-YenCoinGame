using System;
using UnityEngine;

public class GameOverArea : MonoBehaviour
{
    public Action gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            gameOver.Invoke();
        }
    }
}
