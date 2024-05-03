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
        gameManager.tutorialCanvas.SetActive(true);
        gameManager.newGun.SetActive(true);
    }

    public void Update()
    {
        gameManager.stateMachine.TransitionTo(gameManager.stateMachine.mainMenuState);
    }
    public void Exit() 
    {
        Debug.Log("Sale de Tutorial");
        gameManager.blueRing.GetComponentInChildren<BoxCounter>().ResetScore();
        gameManager.redRing.GetComponentInChildren<BoxCounter>().ResetScore();
        gameManager.yellowRing.GetComponentInChildren<BoxCounter>().ResetScore();
        gameManager.tutorialCanvas.SetActive(false);
        gameManager.newGun.SetActive(false);
    }
}
