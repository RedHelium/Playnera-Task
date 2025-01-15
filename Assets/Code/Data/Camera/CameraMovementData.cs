
using System.Collections.Generic;
using Task.Repos;
using Task.States.Base;
using UnityEngine;

namespace Task.Data.Camera
{
    /// <summary>
    /// Данные для движения камеры
    /// </summary>
    public sealed class CameraMovementData
    {
        /// <summary>
        /// Начальная позиция касания
        /// </summary>
        public Vector3 StartTouchPosition;

        /// <summary>
        /// Начальная позиция камеры
        /// </summary>
        public Vector3 StartCameraPosition;

        /// <summary>
        /// Состояния для движения камеры
        /// </summary>
        public Dictionary<TouchPhase, BaseState<CameraFields, CameraMovementData>> States = new();  

        /// <summary>
        /// Текущее состояние движения камеры
        /// </summary>
        public BaseState<CameraFields, CameraMovementData> CurrentState;

        /// <summary>
        /// Касание
        /// </summary>
        public Touch Touch;

        /// <summary>
        /// Скорость движения камеры
        /// </summary>
        public Vector3 Velocity = Vector3.zero;
    }
}
