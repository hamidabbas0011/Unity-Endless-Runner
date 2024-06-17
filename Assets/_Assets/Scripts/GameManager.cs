using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public PlayerControl _PlayerControl;
    
    private void Start()
    {
        _PlayerControl = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        if (_PlayerControl == null)
        {
            Debug.LogError("Player not found!");
        }
        
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void onClickMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void onClickPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickResume()
    {
        Time.timeScale = 1;
        
    }
    
    
    
    

    
}
