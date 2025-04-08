using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameOverCanvas goCanvas;
    [SerializeField] BestScoreCanvas bsCanvas;
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
        rank = bsCanvas.CalcurateRank(score);
        goCanvas.UpdateResult();
    }

#if UNITY_EDITOR
    // 베스트 스코어 리셋
    [MenuItem("FlappyBird/Reset BestScore")]
    public static void ResetBestScore()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Reset best score...done");
    }
#endif
}
