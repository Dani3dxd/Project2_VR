using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

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
        gameManager.blueRing.GetComponentInChildren<BoxCounter>().ResetScore();
        gameManager.redRing.GetComponentInChildren<BoxCounter>().ResetScore();
        gameManager.yellowRing.GetComponentInChildren<BoxCounter>().ResetScore();
        /*gameManager.blueRing.GetComponentInChildren<BoxCounter>().GetScore();
        gameManager.redRing.GetComponentInChildren<BoxCounter>().GetScore();
        gameManager.yellowRing.GetComponentInChildren<BoxCounter>().GetScore();
        gameManager.blueRing.GetComponentInChildren<BoxCounter>().GetTotalItems();
        gameManager.redRing.GetComponentInChildren<BoxCounter>().GetTotalItems();
        gameManager.yellowRing.GetComponentInChildren<BoxCounter>().GetTotalItems();*/
        Debug.Log("Show score state - exit");
        gameManager.saveMenuCanvas.SetActive(false);
    }
}
