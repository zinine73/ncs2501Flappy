using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameOverCanvas canvas;
    int score = 0;
    int rank = 0;

    public int Score => score;
    public int Rank => rank;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void CheckBestScore()
    {
        // todo 랭크 계산
        rank = 0;
        canvas.UpdateResult();
    }
}
