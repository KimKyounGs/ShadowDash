using UnityEngine;

/// <summary>
/// 플레이어의 상태를 관리하는 기본 클래스.
/// 이 클래스를 상속하여 다양한 플레이어 상태(예: Idle, Running, Jumping 등)를 구현할 수 있음.
/// </summary>
public class PlayerState 
{
    // 플레이어의 상태를 관리하는 상태 머신 참조
    protected PlayerStateMachine stateMachine;
    
    // 현재 플레이어 객체 참조
    protected Player player;

    // 애니메이션에서 사용할 상태 변수 이름 (애니메이션 트리거로 활용 가능)
    private string animBoolName;

    /// <summary>
    /// 상태 클래스의 생성자. 
    /// 플레이어 객체, 상태 머신, 애니메이션 트리거 이름을 초기화함.
    /// </summary>
    /// <param name="_player">플레이어 객체</param>
    /// <param name="_stateMachine">플레이어 상태 머신</param>
    /// <param name="_animBoolName">애니메이션 트리거 변수 이름</param>
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;            // 플레이어 객체 저장
        this.stateMachine = _stateMachine; // 상태 머신 저장
        this.animBoolName = _animBoolName; // 애니메이션 트리거 변수 이름 저장
    }

    /// <summary>
    /// 상태가 시작될 때 호출되는 함수.
    /// 해당 상태가 활성화될 때 필요한 초기화 로직을 구현.
    /// </summary>
    public virtual void Enter()
    {
        // 상태 진입 시 수행할 동작을 여기에 구현 (예: 애니메이션 설정 등)
    }

    /// <summary>
    /// 매 프레임마다 호출되는 함수.
    /// 해당 상태에서 지속적으로 수행해야 할 로직을 구현.
    /// </summary>
    public virtual void Update()
    {
        // 상태 업데이트 시 수행할 동작을 여기에 구현 (예: 이동 처리 등)
    }

    /// <summary>
    /// 상태가 종료될 때 호출되는 함수.
    /// 상태가 변경될 때 필요한 정리 작업을 수행.
    /// </summary>
    public virtual void Exit()
    {
        // 상태 종료 시 수행할 동작을 여기에 구현 (예: 애니메이션 해제 등)
    }   
}