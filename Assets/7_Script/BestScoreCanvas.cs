using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BestScoreCanvas : MonoBehaviour
{
    public const int MAX_RANK = 5; // 최대 랭크 보여줄 갯수

    // DateTime을 string형식으로 바꿀때 쓸 패턴
    public static string DTPattern = @"yyMMddhhmmss"; 

    [SerializeField] RankUI[] ranking;

    private void Start()
    {
        for (int i = 0; i < MAX_RANK; i++)
        {
            // 키값이 없으면 "250408120000"의 마지막 값만 바꾼 것을 디폴트로 만든다
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"25040812000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            // BestScore에 각 랭크 내용 전달
            ranking[i].SetRank(i, value, key);
        }
    }

    public int CalcurateRank(int score)
    {
        // 현재 저장된 1~5 순위 값을 딕셔너리를 사용해 저장
        Dictionary<string, int> rankDic = new Dictionary<string, int>();
        for (int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"25040812000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            rankDic.Add(key, value);
        }

        // 현재 일시를 패턴을 이용해 키값으로 만들고
        string nowKey = DateTime.Now.ToString(DTPattern);
        // 딕셔너리에 저장 => 총 갯수가 MAX_RANK + 1
        rankDic.Add(nowKey, score);
        // 내림차순으로 정렬한 값을 새로운 딕셔너리에 저장
        var newDic = rankDic.OrderByDescending(x => x.Value);
        // 반환값으로 최대값을 설정하고
        int nowRanking = MAX_RANK;
        // 인덱스는 0으로 시작
        int index = 0;
        foreach (var item in newDic)
        {
            PlayerPrefs.SetString($"RANKDATE{index}", item.Key);
            PlayerPrefs.SetInt($"RANKSCORE{index}", item.Value);
            // 현재 item이 nowKey값과 같으면 그때 인덱스가 랭크값
            if (item.Key.Equals(nowKey))
            {
                nowRanking = index;
            }
            // 최대랭크 수만큼 돌았으면 나가기
            if (++index == MAX_RANK) break;
        }
        // 랭크값 반환
        return nowRanking;
    }
}
