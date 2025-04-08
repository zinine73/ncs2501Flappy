using System.Text;
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

        // string연산을 많이 하게 되므로 stringBuilder를 사용
        // "250408132704" => "2025/04/08(줄바꿈)13:27:04" 형식으로 보이게 만든다
        StringBuilder sb = new StringBuilder();
        sb.Append("20");
        sb.Append(dt.Substring(0, 2));
        sb.Append("/");
        sb.Append(dt.Substring(2, 2));
        sb.Append("/");
        sb.Append(dt.Substring(4, 2));
        sb.Append("\n");
        sb.Append(dt.Substring(6, 2));
        sb.Append(":");
        sb.Append(dt.Substring(8, 2));
        sb.Append(":");
        sb.Append(dt.Substring(10, 2));
        // stringBuilder 값을 넘길때는 ToString 잊지말자
        dateText.text = sb.ToString();

        // 점수 표시
        scoreText.text = score.ToString();
    }
}
