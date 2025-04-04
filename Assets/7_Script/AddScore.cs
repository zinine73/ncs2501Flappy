using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] int scoreValue; // 파이프 종류별로 얻게 되는 점수 지정
    [SerializeField] AudioClip acPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // "Player"라는 태그로 들어온 트리거만 인식
        if (collision.gameObject.CompareTag("Player"))
        {
            // 점수 획득 소리
            GameManager.Instance.PlayAudio(acPoint);
            // scoreValue값을 실제 score에 업데이트
            ScoreManager.Instance.UpdateScore(scoreValue);
        }
    }
}
