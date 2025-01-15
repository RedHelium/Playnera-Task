using Task.Data.Camera;
using Task.Repos;
using Task.States.Base;
using UnityEngine;

namespace Task.States.Movement
{
    /// <summary>
    /// Состояние движения камеры
    /// </summary>
    public sealed class ContinueMovementState : BaseState<CameraFields, CameraMovementData>
    {
        public ContinueMovementState(CameraFields fields, CameraMovementData data) : base(fields, data)
        {
        }

        public override void Update()
        {
            Movement();
        }

        /// <summary>
        /// Движение камеры
        /// </summary>
        private void Movement()
        {                       
            Vector3 targetPosition = CalculateNewPosition();            
            
            Fields.Camera.SetPosition(targetPosition);
        }

        /// <summary>
        /// Вычисление новой позиции камеры
        /// </summary>
        private Vector3 CalculateNewPosition()
        {
            // Получаем разницу между текущей и начальной позицией касания
            float deltaX = (Data.Touch.position.x - Data.StartTouchPosition.x);
            
            deltaX *= Fields.MovementSensitivity;
            
            // Вычисляем новую позицию камеры только по оси X
            float newX = Data.StartCameraPosition.x - deltaX;
            
            // Ограничиваем движение камеры в пределах заданных границ
            newX = Mathf.Clamp(newX, Fields.MinMovementPositionX, Fields.MaxMovementPositionX);
            
            Vector3 targetPosition = new Vector3(newX, Fields.Camera.Position.y, Fields.Camera.Position.z);
            
            return Vector3.SmoothDamp(
                Fields.Camera.Position, 
                targetPosition, 
                ref Data.Velocity, 
                Fields.MovementSmoothTime
            );
        }

    }
}
