using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void VerCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {

        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }


}
