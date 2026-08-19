using Unity.VisualScripting;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private Transform spawnArea;
    [SerializeField] GameObject Player; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnArea = GetComponent<Transform>();
        Instantiate(Player,spawnArea);
    }
}
