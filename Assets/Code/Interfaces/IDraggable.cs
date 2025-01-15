
using UnityEngine;

namespace Task.Interfaces
{
    /// <summary>
    /// Интерфейс перемещаемого объекта
    /// </summary>
    public interface IDraggable
    {
        /// <summary>
        public Vector2 Position { get; }

        /// <summary>
        /// Начало перемещения
        /// </summary>
        public void StartDragging();

        /// <summary>
        /// Продолжение перемещения
        /// </summary>
        public void ContinueDragging(Vector2 position);

        /// <summary>
        /// Остановка перемещения
        /// </summary>
        public void StopDragging();
    }
}
