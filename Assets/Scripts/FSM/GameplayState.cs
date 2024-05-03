using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GameplayState : IState
{
    private GameManager gameManager;

    public GameplayState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Enter()
    {
        Debug.Log("Game play state - enter");
        gameManager.tempoCanvas.SetActive(true);
        gameManager.newGun.SetActive(true);
        gameManager.Gameplay();
    }

    public void Update()
    {
        Debug.Log("Game play state - update");
    }

    public void Exit()
    {
        gameManager.tempoCanvas.SetActive(false);
        Debug.Log("Game play state - exit");
    }
}
