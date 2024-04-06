using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseScript : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField]
    private GameObject pauseMenu;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerInput.pauseHandler += Pause;
    }

    void Pause()
    {
        Time.timeScale = 0;
        playerInput.SetInputActive(false);
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        playerInput.SetInputActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
