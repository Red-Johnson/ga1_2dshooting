using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null;
    public static ScoreManager Instance => _instance;

    public Text CurrentScoreTextUI;
    private int _currentScore;

    public Text BestScoreTextUI;
    private int _bestScore;

    public int Score => _currentScore;
    public int BestScore => _bestScore;


    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public void Spend(int amount)
    {
        _currentScore -= amount;
        CurrentScoreTextUI.text = $"Score: {_currentScore}";
    }

    public void SetScore(int score)
    {
        if (score < 0)
        {
            return;
        }

        _currentScore = score;
        CurrentScoreTextUI.text = $"Score: {_currentScore}";

        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;

            BestScoreTextUI.text = $"BestScore: {_bestScore}";

            PlayerPrefs.SetInt("BestScore", _bestScore);
        }
    }

    public int GetScore()
    {
        return _currentScore;
    }


    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);

        BestScoreTextUI.text = $"BestScore: {_bestScore}";
    }
}