using Unity.VectorGraphics;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KaaroScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadMainMenu();
        }
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(2);
    }
}
