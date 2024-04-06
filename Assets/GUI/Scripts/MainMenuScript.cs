using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region MainMenu
    public void StartGame()
    {
        Debug.Log("Start Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }
    #endregion

    #region OptionsMenu
    public void UpdateMasterVolume(float volume)
    {
        Debug.Log("Master Volume: " + volume);
        gameManager.MasterVolume = volume;

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
