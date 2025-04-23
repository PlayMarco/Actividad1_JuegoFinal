using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public GameObject gameoverPanel;
    public GameObject lingotesPanel;
    public GameObject victoriaPanel;
    public InputManagerSO inputManager;

    public void MostrarGameover()
    {
        Time.timeScale = 0;
        gameoverPanel.SetActive(true);
        lingotesPanel.SetActive(false);

        inputManager.EnableUI();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameoverPanel.SetActive(false);
        lingotesPanel.SetActive(true);

        inputManager.EnablePlayer();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      
    }

    public void MostrarVictoria()
    {
        Time.timeScale = 0;
        victoriaPanel.SetActive(true);
        lingotesPanel.SetActive(false);

        inputManager.EnableUI();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarJuego()
    { 
        Application.Quit();
    }

}
