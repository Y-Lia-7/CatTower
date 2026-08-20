using Unity.VectorGraphics;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KaaroScript : MonoBehaviour
{
 [SerializeField] Timer timer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float finalTime = timer.GetTime();

            PlayerPrefs.SetFloat("CurrentTime", finalTime);
            PlayerPrefs.Save();

            SceneManager.LoadScene(2);
        }
    }
}
