
using Task.Data.Camera;
using Task.Repos;
using Task.States.Base;

namespace Task.States.Movement
{
    /// <summary>
    /// Состояние остановки движения камеры
    /// </summary>
    public sealed class StopMovementState : BaseState<CameraFields, CameraMovementData>
    {
        public StopMovementState(CameraFields fields, CameraMovementData data) : base(fields, data)
        {
        }

    }
}
