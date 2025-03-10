using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterHUD : MonoBehaviour
{
    [SerializeField] private GameObject bombHUD;
    [SerializeField] private GameObject speedBoostHUD;
    [SerializeField] private GameObject blastRadiusHUD;
    [SerializeField] private TextMeshProUGUI currentBombsText;

    private void Start()
    {
        bombHUD.gameObject.SetActive(true);
        speedBoostHUD.gameObject.SetActive(false);
        blastRadiusHUD.gameObject.SetActive(false);
    }
    public void UpdatePlayerBombs(int currentBombs)
    {
        currentBombsText.text = "X"+currentBombs.ToString();
    }
    public void ShowSpeedBoost()
    {
        speedBoostHUD.SetActive(true);
    }
    public void HideSpeedBoost()
    {
        speedBoostHUD.SetActive(false);
    }
    public void ShowBlastRadius()
    {
        blastRadiusHUD.gameObject.SetActive(true);
    }
    public void HideBlastRadius()
    {
        blastRadiusHUD.gameObject.SetActive(false);
    }

}
