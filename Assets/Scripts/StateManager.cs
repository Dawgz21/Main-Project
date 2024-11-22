using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    //I know only needed one of these and not both, but I had aready assigned
    //them both two different things and was just too lazy to go switch half
    //of them to the other

    public void LoadLevel(string levelName)
    {
  
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        
    }
}
