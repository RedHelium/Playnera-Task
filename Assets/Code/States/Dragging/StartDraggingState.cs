using Task.Data.Camera;
using Task.Extensions;
using Task.Interfaces;
using Task.Repos;
using Task.States.Base;
using UnityEngine;

namespace Task.States.Dragging
{
    /// <summary>
    /// Состояние начала перемещения объекта
    /// </summary>
    public sealed class StartDraggingState : BaseState<CameraFields, CameraDraggingData>
    {
        public StartDraggingState(CameraFields fields, CameraDraggingData data) : base(fields, data)
        {
        }

        public override void Enter()
        {
            HandleRaycast();
        }

        /// <summary>
        /// Обработка луча для перемещения объекта
        /// </summary>
        private void HandleRaycast()
        {
            // Конвертируем позицию касания в мировые координаты
            Vector2 touchWorldPosition = Fields.Camera.Camera.ScreenToWorldPoint(Data.Touch.position);
            
            // Выполняем 2D raycast
            Data.TouchHit = Physics2D.Raycast(
                touchWorldPosition, 
                Vector2.zero, 
                Fields.RaycastDistance, 
                Fields.RaycastDraggableLayer
            );

            if (Data.TouchHit.collider != null)
            {
                Debug.Log($"TouchHit: {Data.TouchHit.collider.gameObject.name}");
                Data.DraggedObject = Data.TouchHit.GetHitComponent<IDraggable>();
                
                CalculateTouchOffset(touchWorldPosition);
                Data.DraggedObject.StartDragging();
            }
        }

        /// <summary>
        /// Вычисление смещения касания
        /// </summary>
        private void CalculateTouchOffset(Vector2 touchWorldPosition)
        {
            Data.TouchOffset = Data.DraggedObject.Position - touchWorldPosition;
        }      
    }
}
