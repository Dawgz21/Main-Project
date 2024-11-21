using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static Levels main;

    [SerializeField] private TextMeshProUGUI strokeUI;

    [SerializeField] private GameObject levelFinishedUI;
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

    public void LevelFinished()
    {
        levelFinished = true;
        if(SceneManager.GetActiveScene().buildIndex == 9){
            levelFinishedStrokeUI.text = strokes > 1 ? "You putted in " + strokes + " strokes" :
                "Hole in one!!!";
            //levelFinishedStrokeUI.text = "You completed the course in " + totalScore + " strokes!";
            levelFinishedUI.SetActive(true);
            ScoreManager.Instance.UpdateScore(strokes);
        }
        else
        {
            levelFinishedStrokeUI.text = strokes > 1 ? "You putted in " + strokes + " strokes" :
                "Hole in one!!!";
            levelFinishedUI.SetActive(true);
            ScoreManager.Instance.UpdateScore(strokes);
        }

    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }



















}
