using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int totalScore = 0;
    public AudioClip buttonPress;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int newScore)
    {
        totalScore += newScore;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    public void playButtonPressSound()
    {
        AudioSource.PlayOneShot(buttonPress);
    }

    public int TotalStrokes()
    {
        return totalScore;
    }
}
