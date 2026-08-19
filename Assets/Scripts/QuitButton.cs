using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // Quits the built game
        Application.Quit();

        // Quits play mode in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
