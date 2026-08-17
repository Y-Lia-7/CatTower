using Unity.XR.Oculus.Input;
using UnityEngine;

public class Hitcheck : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageEnemyPL(other);
    }

    public void DamageEnemyPL(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetComponent<PlayerHealth>().HurtPlayer(damage);
        }
    }
}
