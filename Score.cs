using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;
    private void Start()
    {
        UpdateHighScore();
        UpdateText();
    }

    private void OnEnable()
    {
        FlyBehaviour.ScoreAdded += AddScore;
    }

    private void OnDisable()
    {
        FlyBehaviour.ScoreAdded -= AddScore;
    }

    private void AddScore()
    {
        _score++;
        UpdateHighScore();
        UpdateText();
    }

    private void UpdateText()
    {
        _currentScoreText.text = _score.ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", _score);
    }
}