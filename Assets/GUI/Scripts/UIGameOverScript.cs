using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverScript : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField]
    private GameObject[] endGameMenu;
    
    [SerializeField]
    private GameObject gameOverText;

    private bool gameOver = false;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
    }

    public void ToggleEndGame(bool goodEnding)
    {
        gameOver = true;
        Time.timeScale = 1;
        playerInput.SetInputActive(false);
        if(goodEnding)
        {
            endGameMenu[1].SetActive(true);
        }
        else
        {
            endGameMenu[0].SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(AnimateGameOverText());
    }

    IEnumerator AnimateGameOverText()
    {
        while (gameOver)
        {
            yield return new WaitForSeconds(.5f);
            gameOverText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            gameOverText.SetActive(false);
        }
    }
}
