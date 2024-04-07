using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIObjectiveScript : MonoBehaviour
{
    [SerializeField] private TMP_Text objectiveText;

    [SerializeField] private LevelManager levelManager;

    private PlayerInput playerInput;

    private bool isObjectiveActive = false;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerInput.showObjectiveHandler += ShowObjective;

        levelManager.updateObjectiveHandler += UpdateObjective;
    }

    private void ShowObjective()
    {
        isObjectiveActive = !isObjectiveActive;
        objectiveText?.transform.parent.gameObject.SetActive(isObjectiveActive);
    }

    private void UpdateObjective(string Objective)
    {
        objectiveText.text = Objective;
    }
}
