using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using System;
using PlayFab.ClientModels;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class getBanReason : MonoBehaviour
{

    private TextMeshProUGUI banText;

    // Start is called before the first frame update
    void Start()
    {
        banText = this.GetComponent<TextMeshProUGUI>();

        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        this.GetComponent<TextMeshPro>().text = "You aren't banned how the hell did you get here?";
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        if (error.Error == PlayFabErrorCode.AccountBanned)
        {

            this.GetComponent<TextMeshPro>().text = "You got banned";
        }
    }
 
}