using Microsoft.Extensions.DependencyInjection;
using System.Data;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public string tagToCheck;
    public int health;
    public PlayerMovement Movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        Movement = GetComponent<PlayerMovement>();
        tagToCheck = "Spike";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagToCheck)
        {
            health -= 1;
            if (health <= 0)
            {
                KillPlayer();    
            }
        }
    }

    public void KillPlayer()
    {
        Destroy(Movement);
    }
}
