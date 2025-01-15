using Task.Extensions;
using Task.Interfaces;
using UnityEngine;

namespace Task.Views.Objects
{
    /// <summary>
    /// Представление перемещаемого объекта
    /// </summary>
    public sealed class ObjectView : MonoBehaviour, IView, IDraggable
    {
        [Header("Configuration")]
        [SerializeField] private float _depthScaleMultiplier = 0.1f;
        
        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;
        private float _baseScale;
        private float _baseYPosition;
    
        public Vector2 Position => _transform!.position;
        public Vector3 LocalScale => _transform!.localScale;

        private void Awake() 
        {
            ValidateComponents();

            _baseScale = LocalScale.x;
            _baseYPosition = Position.y;
        }

        /// <summary>
        /// Валидация компонентов
        /// </summary>
        public void ValidateComponents()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();

            this.ValidateComponent(_rigidbody);
            this.ValidateComponent(_collider);
        }

        /// <summary>
        /// Начало перемещения объекта
        /// </summary>
        public void StartDragging()
        {
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            _collider.enabled = false;
        }

        /// <summary>
        /// Перемещение объекта
        /// </summary>
        public void ContinueDragging(Vector2 position)
        {
            _transform!.position = position;
            ChangeScaleBasedOnDepth();
        }

        /// <summary>
        /// Остановка перемещения объекта
        /// </summary>  
        public void StopDragging()
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _collider.enabled = true;
        }

        /// <summary>
        /// Изменение масштаба объекта в зависимости от высоты
        /// </summary>
        private void ChangeScaleBasedOnDepth()
        {
            float yDifference = Position.y - _baseYPosition;
            float scaleModifier = 1f - (yDifference * _depthScaleMultiplier);
            float newScale = _baseScale * scaleModifier;
            
            // Ограничиваем минимальный масштаб, чтобы объект не исчезал полностью
            newScale = Mathf.Max(newScale, _baseScale * 0.1f);
            
            _transform!.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}
