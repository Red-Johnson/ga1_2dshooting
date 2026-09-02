using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    // 목적: 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.
    
    // 필요 필드 :
    public float Speed;
    public float LeftMoveLimit = -2.86f;
    public float RightMoveLimit = 2.86f;
    public float UpMoveLimit = -0.56f;
    public float DownMoveLimit = -5.00f;
    
    
    // Update() 함수는 매 프레임마다 실행된다.
    // 초당 프레임 횟수는 따로 설정하지 않으면 컴퓨터 성능에 따라 다르다.
    private void Update()
    {
        // 모든 게임의 공통된 이동 구현 순서
        // 1. 키보드 입력을 받는다.
        float h = Input.GetAxisRaw("Horizontal");  // 키보드 왼/오른쪽 입력 상태에 따라 -1f ~ 0 ~ 1f 로 반환
        float v = Input.GetAxisRaw("Vertical");    // 키도드 위/아래 입력 상태에 따라 -1f ~ 0 ~ 1f 로 반환
        
        Debug.Log($"h:{h}, v:{v}");
        
        // 2. 키보드 입력에 따라 방향을 구한다.
        // 게임에는 벡터라는 위치 자료형이 있다. 벡터는 크기, 방향을 의미한다.
        Vector2 direction = new Vector2(h, v); // 왼쪽 방향
        // = Vector2 direction = Vector2.left;

        // 3. 방향과 속력에 따라 이동한다.
        //  속도 = 방향 * 속력
        Vector2 fixedDirection = direction.normalized; // 벡터의 길이를 1로 균일화 (대각선 속도 증가 방지)
        transform.Translate(fixedDirection * Speed * Time.deltaTime); // 매직넘버: 보는 사람에 따라 의미가 달라질 수 있는 애매한 숫자 (0.05f처럼) 
        // deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS로 반환
        
        // 새로운 위치 = 현재 위치 + (방향 * 속력 * 시간)
        // transform.position = transform.position + (Vector3)direction * Speed * Time.deltaTime;

        // 현재 위치 값 저장
        Vector2 pos = transform.position;

        // 좌, 우 자동 순간이동 기능
        if (pos.x < LeftMoveLimit)
        {
            pos.x = RightMoveLimit;
        }
        else if (pos.x > RightMoveLimit)
        {
            pos.x = LeftMoveLimit;
        }
        
        transform.position = pos;
        
        // 상, 하 이동 가능 경계
        if (pos.y < DownMoveLimit)
        {
            pos.y = DownMoveLimit;
        }
        else if (pos.y > UpMoveLimit)
        {
            pos.y = UpMoveLimit;
        }
        
        transform.position = pos;
        
        
        
    }
}
