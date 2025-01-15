using Task.Data.Camera;
using Task.Repos;
using Task.States.Dragging;
using UnityEngine;

namespace Task.Controllers.Camera
{
    /// <summary>
    /// Контроллер камеры
    /// </summary>
    public sealed class CameraDraggingController
    {
        private readonly CameraDraggingData _data;
        private readonly CameraFields _fields;

        /// <summary>
        /// Флаг, указывающий на то, что мы перемещаем объект
        /// </summary>
        public bool IsDragging => _data.CurrentState is ContinueDraggingState;

        public CameraDraggingController(CameraFields fields, CameraDraggingData data)
        {
            _fields = fields;
            _data = data;

            Initialize();
        }

        private void Initialize()
        {
            StartDraggingState startDraggingState = new(_fields, _data);
            ContinueDraggingState continueDraggingState = new(_fields, _data);
            StopDraggingState stopDraggingState = new(_fields, _data);

            _data.States.Add(TouchPhase.Began, startDraggingState);
            _data.States.Add(TouchPhase.Moved, continueDraggingState);
            _data.States.Add(TouchPhase.Ended, stopDraggingState);
        }

        /// <summary>
        /// Обработка тача
        /// </summary>
        public void HandleTouch()
        {
             if (Input.touchCount == 0)
                return;

            _data.Touch = Input.GetTouch(0);

            switch (_data.Touch.phase)
            {
                case TouchPhase.Began:
                    ChangeState(TouchPhase.Began);
                    break;

                case TouchPhase.Moved:
                    if(_data.DraggedObject != null)
                        ChangeState(TouchPhase.Moved);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    ChangeState(TouchPhase.Ended);
                    break;
            }
        }

        /// <summary>
        /// Выполнение обновления состояния
        /// </summary>
        public void ExecuteStateUpdate()
        {
            _data.CurrentState?.Update();
        }

        /// <summary>
        /// Изменение состояния
        /// </summary>
        public void ChangeState(TouchPhase phase)
        {
            _data.CurrentState?.Exit();
            _data.CurrentState = _data.States[phase];
            _data.CurrentState?.Enter();
        }
    }
}