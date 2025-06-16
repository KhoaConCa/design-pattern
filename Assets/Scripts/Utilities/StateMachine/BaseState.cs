using System;
using UnityEngine;

namespace TurnBase2D.Utilities.StateMachine
{
    /// <summary>
    /// BaseState<EState> - Là một abstract class đại diện cho một state trong State Machine.
    /// Tác giả: Dương Nhật Khoa - Ngày tạo: 16/06/2025.
    /// </summary>
    /// <typeparam name="EState">State của đối tượng được biểu diễn bằng Enum</typeparam>
    public abstract class BaseState<EState> where EState : Enum
    {
        #region --- Contructor ---

        public BaseState(EState key)
        {
            StateKey = key;
        }

        #endregion

        #region --- Abstract Methods ---

        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public abstract EState GetNextState();
        public abstract void OnTriggerEnter(Collider other);
        public abstract void OnTriggerStay(Collider other);
        public abstract void OnTriggerExit(Collider other);

        #endregion

        #region --- Properties ---

        public EState StateKey { get; private set; }

        #endregion
    }
}
