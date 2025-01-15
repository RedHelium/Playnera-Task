
using System.Collections.Generic;
using Task.Interfaces;
using Task.Repos;
using Task.States.Base;
using UnityEngine;

namespace Task.Data.Camera
{
    /// <summary>
    /// Данные камеры
    /// </summary>
    public sealed class CameraDraggingData
    {
        // Объект, который перемещается
        public IDraggable DraggedObject;
        // Смещение от точки касания до центра объекта
        public Vector3 TouchOffset;
        // Плоскость перемещения на уровне объекта
        public Plane DragPlane;
        // Текущее состояние
        public BaseState<CameraFields, CameraDraggingData> CurrentState;
        // Список состояний
        public Dictionary<TouchPhase, BaseState<CameraFields, CameraDraggingData>> States = new();  
        // Текущий тач
        public Touch Touch;
        // Луч, который проходит через точку касания
        public Ray2D TouchRay;
        // Объект, который перемещается
        public RaycastHit2D TouchHit;
    }
}
