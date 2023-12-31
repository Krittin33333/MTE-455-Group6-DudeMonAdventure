using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text staffText;
    [SerializeField] private TMP_Text LevelText;

    [SerializeField] private TMP_Text farmNameText;
    public TMP_Text FarmNameText
    { get { return farmNameText; } set { farmNameText = value; } }

    public GameObject farmPanel;
    public GameObject laborMarketPanel;
    public GameObject SettingPanel;
    public GameObject tutorialImage;

    public static MainUI instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateResourceUI();
    }

    public void UpdateResourceUI()
    {
        moneyText.text = (Office.instance.Money.ToString()+" ( +" + Office.instance.Income.ToString() + " )");
      //  staffText.text = Office.instance.Workers.Count.ToString();
        LevelText.text = Office.instance.LevelPlayer.ToString();
        //wheatText.text = Office.instance.Wheat.ToString();
    }

    public void ToggleFarmPanel()
    {
        if (!farmPanel.activeInHierarchy)
        {
            farmPanel.SetActive(true);
        }
        else { 
            farmPanel.SetActive(false);
             Debug.Log("Close");
        }
    }

    public void ToggleLaborPanel()
    {
        if (!laborMarketPanel.activeInHierarchy)
            laborMarketPanel.SetActive(true);
        else
            laborMarketPanel.SetActive(false);
    }

    public void ToggleSettingPanel()
    {
        if (!SettingPanel.activeInHierarchy)
            SettingPanel.SetActive(true);
        else
            SettingPanel.SetActive(false);
    }

    public void ToggletutorialImage()
    {
        if (!tutorialImage.activeInHierarchy)
            tutorialImage.SetActive(true);
        else
            tutorialImage.SetActive(false);
    }
    public void ExitScence()
    {
        Application.Quit();
    
    }
}
