using Microsoft.Extensions.DependencyInjection;
using System.Data;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public PlayerMovement Movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        Movement = GetComponent<PlayerMovement>();
    }

    public void HurtPlayer(float damage)
    {
        this.health -= damage;
        
        if (health <= 0)
        {
            Movement.KillPlayer();
        }
    }
}
