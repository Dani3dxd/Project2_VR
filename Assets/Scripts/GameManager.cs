using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [Header("Spawn reference")]
    [SerializeField] public GameObject spawnArea;
   
    [Header("Main menu")]
    [SerializeField] public GameObject mainMenuCanvas;
    [SerializeField] public Button startBtn;

    [Header("Tutorial")]
    [SerializeField] public GameObject tutorialCanvas;
    [SerializeField] public Button mainMenuBtn;
    [SerializeField] public Button tutoBtn;

    [Header("Time menu")]
    [SerializeField] public GameObject tempoCanvas;
    [SerializeField] public TMP_Text tempoTxt;

    [Header("Save Menu")]
    [SerializeField] public GameObject saveMenuCanvas;
    [SerializeField] public Button saveBtn;

    [Header("Gameplay")]
    [SerializeField] public float _duration = 60.0f;

    [Header("Gun")]
    [SerializeField] GameObject spawnGun;

    [Header("Counters")]
    [SerializeField] public GameObject blueRing;
    [SerializeField] public GameObject yellowRing;
    [SerializeField] public GameObject redRing;
    [SerializeField] TMP_Text scoreTotalBlueTxt;
    [SerializeField] TMP_Text scoreTotalYellowTxt;
    [SerializeField] TMP_Text scoreTotalRedTxt;

    public GameObject newGun;
    public StateMachine stateMachine;
    void Start()
    {
        newGun = Instantiate(spawnGun, spawnArea.transform.position, spawnArea.transform.rotation, null);
        stateMachine = new(this);
        stateMachine.Initialize(stateMachine.mainMenuState);
    }
    
    public void Gameplay()
    {
        newGun.SetActive(true);
        //tempoTxt.text = _duration.ToString("F1") + " S";
        StartCoroutine("GameplayTime");
    }
    

    IEnumerator GameplayTime()
    {
        float newduration = _duration;
        while(newduration > 0)
        {
            newduration -= Time.deltaTime;
            tempoTxt.text = newduration.ToString("F1") + " s";
            Debug.Log("Limit time: " +  newduration.ToString("F1"));
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        publishResults();
        stateMachine.TransitionTo(stateMachine.showScoreState);
    }
    public void publishResults()
    {
        BoxCounter counterBlue = blueRing.GetComponentInChildren<BoxCounter>();
        BoxCounter counterRed = redRing.GetComponentInChildren<BoxCounter>();
        BoxCounter counterYellow = yellowRing.GetComponentInChildren<BoxCounter>();
        scoreTotalBlueTxt.text = "you got " + counterBlue.GetScore().ToString() + " points on ring";
        scoreTotalYellowTxt.text = "you got " + counterYellow.GetScore().ToString() + " points on ring";
        scoreTotalRedTxt.text = "you got " + counterRed.GetScore().ToString() + " points on ring";
        
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Ha salido del juego");
    }
}
