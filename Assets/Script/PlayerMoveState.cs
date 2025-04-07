using UnityEngine;

/// <summary>
/// 플레이어의 이동 상태를 정의하는 클래스.
/// PlayerState 클래스를 상속받아 이동 관련 동작을 구현할 수 있음.
/// </summary>
public class PlayerMoveState : PlayerState
{
    /// <summary>
    /// 이동 상태의 생성자.
    /// 플레이어 객체, 상태 머신, 애니메이션 트리거 이름을 부모 클래스에 전달.
    /// </summary>
    /// <param name="_player">플레이어 객체</param>
    /// <param name="_stateMachine">플레이어 상태 머신</param>
    /// <param name="_animBoolName">애니메이션 트리거 변수 이름</param>
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) 
        : base(_player, _stateMachine, _animBoolName)
    {
    }

    /// <summary>
    /// 이동 상태가 시작될 때 실행되는 함수.
    /// 이동 관련 초기화 작업을 수행할 수 있음.
    /// </summary>
    public override void Enter()
    {
        base.Enter(); // 부모 클래스의 Enter() 메서드 호출
    }

    /// <summary>
    /// 이동 상태에서 벗어날 때 실행되는 함수.
    /// 상태 전환 시 필요한 정리 작업을 수행할 수 있음.
    /// </summary>
    public override void Exit()
    {
        base.Exit(); // 부모 클래스의 Exit() 메서드 호출
    }

    /// <summary>
    /// 이동 상태에서 매 프레임마다 실행되는 함수.
    /// 플레이어의 이동 로직을 여기에 구현할 수 있음.
    /// </summary>
    public override void Update()
    {
        base.Update(); // 부모 클래스의 Update() 메서드 호출
    }
}