using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text CurrentScoreTextUI;
    private int _currentScore;

    public Text BestScoreTextUI;
    private int _bestScore;

    public void SetScore(int score)
    {
        if (score < 0)
        {
            return;
        }

        _currentScore = score;
        CurrentScoreTextUI.text = $"현재 점수: {_currentScore}";

        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;

            BestScoreTextUI.text = $"최고 점수: {_bestScore}";

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

        BestScoreTextUI.text = $"최고점수: {_bestScore}";
    }
}