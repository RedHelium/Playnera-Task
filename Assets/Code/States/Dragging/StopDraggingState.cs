
using Task.Data.Camera;
using Task.Repos;
using Task.States.Base;

namespace Task.States.Dragging
{
    /// <summary>
    /// Состояние остановки перемещения объекта
    /// </summary>
    public sealed class StopDraggingState : BaseState<CameraFields, CameraDraggingData>
    {
        public StopDraggingState(CameraFields fields, CameraDraggingData data) : base(fields, data)
        {
        }

        public override void Enter()
        {
            StopDragging();
        }

        /// <summary>
        /// Остановка перемещения объекта
        /// </summary>
        private void StopDragging()
        {
            if(Data.DraggedObject == null)
                return;

            Data.DraggedObject.StopDragging();

            Data.DraggedObject = null; // Можно было бы назначать какой-нибудь пустой объект, но для тестовой задачи решил оставить null
        }
    }
}
