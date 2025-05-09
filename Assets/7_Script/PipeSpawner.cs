using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f;      // 몇초마다 생성할건지
    [SerializeField] float heightRange = 0.5f;  // 생성위치 y의 랜덤 범위
    [SerializeField] GameObject[] pipePrefab;     // 파이프의 프레팝 연결
    [SerializeField] GameObject[] redPipePrefab;  // 빨간 파이프 프레팝
    const int MAX_PIPE = 3; // 오브젝트풀링을 위햐 미리 만들어 놓을 최대 파이프 수
    int pipeIndex = 0; // 오브젝트풀링을 위한 인덱스 저장용 변수
    float timer;
    
    private void Update()
    {
        // 게임상태가 PLAY일때만 파이프를 생성하게 한다
        if (GameManager.Instance.GameState != GameManager.State.PLAY) return;

        // timer가 maxTime을 넘으면
        if (timer > maxTime)
        {
            // pipe를 만드는 함수 호출
            SpawnPipe();
            // timer는 0으로
            timer = 0;
        }
        // timer에 시간 더하기
        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        // 랜덤으로 y값을 정해서, 생성될 파이프의 위치 정하기
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        // 랜덤으로 녹색, 빨간색 파이프 선택
        //GameObject pipePf = (Random.Range(0, 100) > 10) ? pipePrefab : redPipePrefab;
        // Instantiate로 생성, 생성된 객체는 pipe라는 GameObject에 할당
        //GameObject pipe = Instantiate(pipePf, spawnPos, Quaternion.identity);
        // 7초 뒤에 pipe 객체 파괴
        //Destroy(pipe, 7f);

        // 오브젝트풀링
        if (Random.Range(0, 100) > 10)
        {
            pipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        else
        {
            redPipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            redPipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        // 최대파이프갯수에 도달하면
        if (++pipeIndex == MAX_PIPE)
        {
            // 인덱스를 다시 0으로 시작
            pipeIndex = 0;
        }
    }
}
