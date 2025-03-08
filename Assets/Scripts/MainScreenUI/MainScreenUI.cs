using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainScreenUI : MonoBehaviour
{
    [SerializeField] private Button startButton; 
    [SerializeField] private Button howToPlayButton; 
    [SerializeField] private Button quitButton;

    [SerializeField] private Button closeInfoPanelButton;

    [SerializeField] private GameObject howToPlayPanel;


    private void Start()
    {
        startButton.onClick.AddListener(PlayGameScene);
        howToPlayButton.onClick.AddListener(ShowInfoPanel);
        closeInfoPanelButton.onClick.AddListener(CloseInfoPanel);
    }
    private void PlayGameScene()
    {
        SceneManager.LoadScene("Bomberman");
    }
    private void ShowInfoPanel()
    {
        howToPlayPanel.SetActive(true);
    }
    private void CloseInfoPanel()
    {
        howToPlayPanel.SetActive(false);
    }








}
