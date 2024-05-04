using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : IState
{
    private GameManager gameManager;

    public TutorialState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    public void Enter()
    {
        Debug.Log("Entre a Tutorial");
        gameManager.mainMenuBtn.onClick.AddListener(Update);
        gameManager.newGun.SetActive(true);
        gameManager.tutorialCanvas.SetActive(true);
        
    }

    public void Update()
    {
        gameManager.stateMachine.TransitionTo(gameManager.stateMachine.gameplayState);
    }
    public void Exit() 
    {
        Debug.Log("Sale de Tutorial");
        gameManager.newGun.SetActive(false);
        gameManager.tutorialCanvas.SetActive(false);
    }
}
