using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuState : IState
{
    private GameManager gameManager;

    public MainMenuState(GameManager gameManager) 
    {
        this.gameManager = gameManager;
    }

    public void Enter()
    {
        Debug.Log("Estado main menu - enter");
        gameManager.tutoBtn.onClick.AddListener(Tutorial);
        gameManager.startBtn.onClick.AddListener(Update);
        gameManager.mainMenuCanvas.SetActive(true);
        gameManager.blueRing.SetActive(false);
        gameManager.redRing.SetActive(false);
        gameManager.yellowRing.SetActive(false);
        gameManager.newGun.SetActive(false);
        gameManager.newGun.transform.position = gameManager.spawnArea.transform.position;
        gameManager.newGun.transform.rotation = gameManager.spawnArea.transform.rotation;
    }        

    public void Update()
    {
        Debug.Log("Estado main menu - update");
        gameManager.stateMachine.TransitionTo(gameManager.stateMachine.gameplayState);
        
    }

    public void Tutorial()
    {
        Debug.Log("Estado main menu - updateTuto");
        gameManager.stateMachine.TransitionTo(gameManager.stateMachine.tutorialState);
    }

    public void Exit()
    {
        Debug.Log("Estado main menu - exit");
        gameManager.mainMenuCanvas.SetActive(false);
        gameManager.blueRing.SetActive(true);
        gameManager.redRing.SetActive(true);
        gameManager.yellowRing.SetActive(true);
    }
}
