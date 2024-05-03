using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class CloudSave : Singleton<CloudSave>
{
    [SerializeField] GameObject blueRing;
    [SerializeField] GameObject yellowRing;
    [SerializeField] GameObject redRing;


    struct dataToSave
    {
        public int scoreBlue;
        public int scoreRed;
        public int scoreYellow;
    }

    async void Start()
    {
        // Initialize unity services
        await UnityServices.InitializeAsync();

        // Setup events listeners
        SetupEvents();

        // Unity Login
        await SignInAnonymouslyAsync();
    }
   
    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };
    }

    async Task SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");
        }
        catch (Exception ex)
        {
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    public async void SaveDataCloud()
    {
        BoxCounter counterBlue = blueRing.GetComponentInChildren<BoxCounter>();
        BoxCounter counterRed = redRing.GetComponentInChildren<BoxCounter>();
        BoxCounter counterYellow = yellowRing.GetComponentInChildren<BoxCounter>();

        Debug.Log("Voy a guardar");
       
        dataToSave performance = new();
        performance.scoreBlue = counterBlue.GetScore();
        performance.scoreRed = counterRed.GetScore();
        performance.scoreYellow = counterYellow.GetScore();

        var data = new Dictionary<string, object> { { "Perfomance", performance } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        Debug.Log("Exito!");
    }
}