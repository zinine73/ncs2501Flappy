using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankUI : MonoBehaviour
{
    [SerializeField] Image medal;
    [SerializeField] TMP_Text rankText;
    [SerializeField] TMP_Text dateText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Sprite[] medalSprite;

    public int inputrank;

    void Start()
    {
        SetRank(inputrank, 99, null);
    }
    public void SetRank(int rank, int score, string dt)
    {
        // 랭크가 3 이상이면 3을, 아니면 그 값을 인덱스로 한다
        int medalIndex = (rank > 2) ? 3 : rank;
        // 메달스프라이트에 있는 메달 선택
        medal.sprite = medalSprite[medalIndex];
        // 랭크 값은 0부터이므로 +1
        rankText.text = (rank + 1).ToString();
        // 랭크가 3 이상일때만 표시
        rankText.gameObject.SetActive(rank > 2);

    }
}
