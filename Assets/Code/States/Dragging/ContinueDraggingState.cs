using Task.Data.Camera;
using Task.Extensions;
using Task.Repos;
using Task.States.Base;
using UnityEngine;

namespace Task.States.Dragging
{
    /// <summary>
    /// Состояние продолжения перемещения объекта
    /// </summary>
    public sealed class ContinueDraggingState : BaseState<CameraFields, CameraDraggingData>
    {
        public ContinueDraggingState(CameraFields fields, CameraDraggingData data) : base(fields, data)
        {
        }

        public override void Update()
        {
            ContinueDragging();
        }

        /// <summary>
        /// Перемещает объект
        /// </summary>
        private void ContinueDragging()
        {
            if (Data.DraggedObject == null)
                return;

            Vector2 touchWorldPosition = Fields.Camera.Camera.ScreenToWorldPoint(Data.Touch.position);
            
            Vector2 newPosition = touchWorldPosition.ToVector3() + Data.TouchOffset;
            
            Data.DraggedObject.ContinueDragging(newPosition);
        }
     
    }
}
