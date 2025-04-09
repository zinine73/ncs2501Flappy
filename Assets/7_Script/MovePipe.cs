using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] float speed = 0.65f;
    [SerializeField] BoxCollider2D upPipe;
    [SerializeField] BoxCollider2D downPipe;
    public bool Moving { get; set; }
    
    private void Update()
    {
        // 게임상태가 PLAY일때만 움직이도록
        if (GameManager.Instance.GameState == GameManager.State.PLAY)
        {
            if (Moving) // 오브젝트풀링에서 움직임 시작 조정
            {
                // 파이프의 위치를 speed만큼 좌로 이동
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else if (GameManager.Instance.GameState == GameManager.State.GAMEOVER)
        {
            // 게임오버상태에서는 파이프의 충돌이 안 일어나게
            upPipe.enabled = downPipe.enabled = false;
        }
    }
}
