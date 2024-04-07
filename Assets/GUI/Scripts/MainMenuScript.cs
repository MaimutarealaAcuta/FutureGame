using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject optionsPanel;

    [SerializeField]
    private GameObject creditsPanel;

    [SerializeField]
    private GameManager gameManager;

    bool isOptionsActive = false;
    bool isCreditsActive = false;


    void Start()
    {
        gameManager.passedTutorial = false;
        gameManager.solvedFire = false;
        gameManager.solvedPoison = false;
        gameManager.solvedLetter = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region MainMenu
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("SpaceShipHub");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    #endregion

    #region OptionsMenu
    public void UpdateMasterVolume(float volume)
    {
        Debug.Log("Master Volume: " + volume);
        gameManager.MasterVolume = volume;
        AudioListener.volume = volume;

    }
    #endregion

    public void ToggleOptions()
    {
        Debug.Log("Toggle Options");

        isOptionsActive = !isOptionsActive;
        mainMenuPanel.SetActive(!isOptionsActive);
        optionsPanel.SetActive(isOptionsActive);
    }

    public void ToggleCredits()
    {
        Debug.Log("Toggle Credits");

        isCreditsActive = !isCreditsActive;
        mainMenuPanel.SetActive(!isCreditsActive);
        creditsPanel.SetActive(isCreditsActive);
    }

}
