using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScoreState : IState
{
    private GameManager gameManager;

    public ShowScoreState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Enter()
    {
        Debug.Log("Show score state - enter");
        gameManager.saveBtn.onClick.AddListener(Update);
        gameManager.saveMenuCanvas.SetActive(true);
    }

    public void Update()
    {
        Debug.Log("Show score state - update");
        gameManager.stateMachine.TransitionTo(gameManager.stateMachine.mainMenuState);
    }

    public void Exit()
    {
        Debug.Log("Show score state - exit");
        gameManager.saveMenuCanvas.SetActive(false);
    }
}
