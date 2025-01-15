
using UnityEngine;

namespace Task.Views.Core
{
    /// <summary>
    /// Представление камеры
    /// </summary>
    public sealed class CameraView : BaseView<Camera>
    {
        private Transform _transform;

        public Vector3 Position => _transform.position;

        public Camera Camera => Component;

        public override void ValidateComponents()
        {
            base.ValidateComponents();
            _transform = transform;
        }

        /// <summary>
        /// Установка позиции камеры
        /// </summary>
        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}
