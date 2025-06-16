using UnityEngine;
using System;
using System.Collections.Generic;

namespace TurnBase2D.Utilities.StateMachine
{
    /// <summary>
    /// StateManager<EState> - Là một abstract class đại diện cho quản lý state trong State Machine.
    /// Tác giả: Dương Nhật Khoa - Ngày tạo: 16/06/2025.
    /// </summary>
    /// <typeparam name="EState">Các state của đối tượng được viết dưới dạng Enum</typeparam>
    public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
    {
        #region --- Unity Methods ---

        void Start()
        {
            currentState.EnterState();
        }

        void Update()
        {
            EState nextStateKey = currentState.GetNextState();

            if (!isTransitioningState && nextStateKey.Equals(currentState.StateKey))
            {
                currentState.UpdateState();
            }
            else
            {
                TransitionToState(nextStateKey);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            currentState.OnTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            currentState.OnTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            currentState.OnTriggerExit(other);
        }

        #endregion

        #region --- Methods ---

        private void TransitionToState(EState nextStateKey)
        {
            isTransitioningState = true;

            currentState.ExitState();
            currentState = states[nextStateKey];
            currentState.EnterState();

            isTransitioningState = false;
        }

        #endregion

        #region --- Fields ---

        protected Dictionary<EState, BaseState<EState>> states = new Dictionary<EState, BaseState<EState>>();
        protected BaseState<EState> currentState;

        protected bool isTransitioningState = false;

        #endregion
    }
}
