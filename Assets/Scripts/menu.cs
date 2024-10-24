using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{

    [SerializeField] private GameObject menuPanels;
    [SerializeField] private GameObject levelPanels;
    [SerializeField] private GameObject settingPanels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToLevelPanel()
    {
        menuPanels.SetActive(false);
        levelPanels.SetActive(true);
        settingPanels.SetActive(false);
    }

    public void GoToMenuPanel()
    {
        menuPanels.SetActive(true);
        levelPanels.SetActive(false);
        settingPanels.SetActive(false);
    }

    public void GoToSettingPanel()
    {
        menuPanels.SetActive(false);
        levelPanels.SetActive(false);
        settingPanels.SetActive(true);
    }
}
