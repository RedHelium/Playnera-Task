using UnityEngine;
using Task.Data.Camera;
using Task.Repos;
using Task.States.Movement;

namespace Task.Controllers.Camera
{
    public sealed class CameraMovementController
    {
        private readonly CameraFields _fields;
        private readonly CameraMovementData _data;
        
        public bool IsMoving => _data.CurrentState is ContinueMovementState;
        
        public CameraMovementController(CameraFields fields, CameraMovementData cameraData)
        {
            _fields = fields;
            _data = cameraData;

            Initialize();
        }

        private void Initialize()
        {
            StartMovementState startMovementState = new(_fields, _data);
            ContinueMovementState continueMovementState = new(_fields, _data);
            StopMovementState stopMovementState = new(_fields, _data);

            _data.States.Add(TouchPhase.Began, startMovementState);
            _data.States.Add(TouchPhase.Moved, continueMovementState);
            _data.States.Add(TouchPhase.Ended, stopMovementState);
        }

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
                    ChangeState(TouchPhase.Moved);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    ChangeState(TouchPhase.Ended);
                    break;
            }
        }

        public void ChangeState(TouchPhase phase)
        {
            _data.CurrentState?.Exit();
            _data.CurrentState = _data.States[phase];
            _data.CurrentState?.Enter();
        }

        public void ExecuteStateUpdate()
        {
            _data.CurrentState?.Update();
        }

    }
}
