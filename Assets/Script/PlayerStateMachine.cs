using UnityEngine;

/// <summary>
/// 플레이어의 상태를 관리하는 상태 머신 클래스.
/// 플레이어가 가질 수 있는 다양한 상태를 전환하는 역할을 함.
/// </summary>
public class PlayerStateMachine 
{
    /// <summary>
    /// 현재 활성화된 상태를 저장하는 프로퍼티.
    /// 외부에서 직접 변경할 수 없도록 private set 사용.
    /// </summary>
    public PlayerState currentState { get; private set; }
 
    /// <summary>
    /// 상태 머신을 초기화하는 함수.
    /// 게임 시작 시 또는 플레이어가 처음 특정 상태로 설정될 때 호출됨.
    /// </summary>
    /// <param name="_startState">초기 상태로 설정할 PlayerState 객체</param>
    public void Initialize(PlayerState _startState)
    {
        currentState = _startState; // 초기 상태 설정
        currentState.Enter();       // 초기 상태의 Enter() 메서드 호출 (상태 진입 처리)
    }

    /// <summary>
    /// 현재 상태를 새로운 상태로 변경하는 함수.
    /// 기존 상태의 Exit()을 호출하고, 새로운 상태의 Enter()을 호출하여 전환을 수행.
    /// </summary>
    /// <param name="_newState">새롭게 변경할 PlayerState 객체</param>
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();     // 기존 상태의 Exit() 메서드 호출 (상태 종료 처리)
        currentState = _newState; // 새로운 상태로 변경
        currentState.Enter();    // 새로운 상태의 Enter() 메서드 호출 (상태 진입 처리)
    }
}