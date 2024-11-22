using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    //Robbie helped me with some of this
    public static Levels main;

    [SerializeField] private TextMeshProUGUI strokeUI;

    [SerializeField] private GameObject levelFinishedUI;
    [SerializeField] private TextMeshProUGUI messageUI;
    [SerializeField] private TextMeshProUGUI levelFinishedStrokeUI;

    [SerializeField] private GameObject gameOverUI;

    private int strokes;
  

    [HideInInspector] public bool levelFinished;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        UpdateStrokeUI();

    }

    private void UpdateStrokeUI()
    {
        strokeUI.text = strokes + "";
    }

    public void IncreaseStroke()
    {
        strokes++;
        UpdateStrokeUI();
    }

    //Robbie helped me with this method 
    public void LevelFinished()
    {
        levelFinished = true;
        if(SceneManager.GetActiveScene().buildIndex == 9){
            ScoreManager.Instance.UpdateScore(strokes);
            int totalStrokes = ScoreManager.Instance.TotalStrokes();
            messageUI.text = strokes > 1 ? "You putted in " + strokes + " strokes" :
                "Hole in one!!!";
            levelFinishedStrokeUI.text = "You completed the course in " + totalStrokes + " strokes!";
            levelFinishedUI.SetActive(true);
        }
        else
        {
            ScoreManager.Instance.UpdateScore(strokes);
            levelFinishedStrokeUI.text = strokes > 1 ? "You putted in " + strokes + " strokes" :
                "Hole in one!!!";
            levelFinishedUI.SetActive(true);
            
        }

    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }



















}
