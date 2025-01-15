
using Task.Extensions;
using Task.Interfaces;
using UnityEngine;

namespace Task.Views
{
    /// <summary>
    /// Базовое представление (просто почему бы и нет)
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    public abstract class BaseView<TComponent> : MonoBehaviour, IView
    where TComponent : Component
    {
        public TComponent Component { get; private set; }

        public virtual void ValidateComponents()
        {
            Component = GetComponent<TComponent>();
            this.ValidateComponent(Component);
        }

        protected virtual void Awake()
        {
           ValidateComponents();
        }
    }
}