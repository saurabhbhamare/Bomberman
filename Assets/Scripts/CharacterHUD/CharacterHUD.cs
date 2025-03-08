using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour
{
    [SerializeField] private GameObject bombHUD;
    [SerializeField] private GameObject speedBoostHUD;
    [SerializeField] private GameObject blastRadiusHUD;

    private void Start()
    {
        bombHUD.gameObject.SetActive(true);
        speedBoostHUD.gameObject.SetActive(false);
        blastRadiusHUD.gameObject.SetActive(false);
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
    public void ShowExtraBomb()
    {
        bombHUD.gameObject.SetActive(true);
    }
    public void HideExtraBomb()
    {
        bombHUD.gameObject.SetActive(false);
    }



}
