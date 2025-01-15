using System;
using Task.Controllers.Camera;
using Task.Data.Camera;
using Task.Views.Core;
using UnityEngine;

namespace Task.Repos
{


    [Serializable]
    public sealed class CameraFields
    {
        [Header("Core Configuration")]
        public CameraView Camera;
        [Header("Raycast Configuration")]
        public float RaycastDistance;
        public LayerMask RaycastDraggableLayer;
        [Header("Movement Configuration")]
        public float MinMovementPositionX;
        public float MaxMovementPositionX;
        public float MovementSmoothTime;
        public float MovementSensitivity;

    }

    /// <summary>
    /// Репозиторий камеры
    /// </summary>
    public sealed class CameraRepository : MonoBehaviour
    {
        [SerializeField] private CameraFields _fields;
        
        private CameraDraggingData _draggingData = new();
        private CameraMovementData _movementData = new();
        private CameraDraggingController _draggingController;
        private CameraMovementController _movementController;

        private void Awake()
        {
            _draggingController = new CameraDraggingController(_fields, _draggingData); 
            _movementController = new CameraMovementController(_fields, _movementData);
        }

        private void Update()
        {
            Debug.Log($"Move? {_movementController.IsMoving}, Dragging? {_draggingController.IsDragging}");

            // Если мы не двигаемся, то обрабатываем тач для перетаскивания
            if(!_movementController.IsMoving)
            {
                _draggingController.HandleTouch();
                _draggingController.ExecuteStateUpdate();
            }
 
            // Если мы не перемещаем объект, то обрабатываем тач для перемещения
            if(!_draggingController.IsDragging)
            {
                _movementController.HandleTouch();
                _movementController.ExecuteStateUpdate();
            }

        }
    }
}
