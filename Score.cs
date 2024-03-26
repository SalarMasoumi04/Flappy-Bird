using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    public Score Instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;
    internal static object instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _currentScoreText.text = _score.ToString();

        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }
    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }
    }
    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }
}