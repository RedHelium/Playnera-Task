
using Task.Data.Camera;
using Task.Repos;
using Task.States.Base;

namespace Task.States.Movement
{
    /// <summary>
    /// Состояние начала движения камеры
    /// </summary>
    public sealed class StartMovementState : BaseState<CameraFields, CameraMovementData>
    {
        public StartMovementState(CameraFields fields, CameraMovementData data) : base(fields, data)
        {
        }

        public override void Enter()
        {
            SetStartPosition();
        }

        /// <summary>
        /// Установка начальной позиции камеры
        /// </summary>
        private void SetStartPosition()
        {
            Data.StartTouchPosition = Data.Touch.position;
            Data.StartCameraPosition = Fields.Camera.Position;
        }

    }
}
