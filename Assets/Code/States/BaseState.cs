
namespace Task.States.Base
{
    /// <summary>
    /// Базовое состояние
    /// </summary>
    /// <typeparam name="TFields"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public abstract class BaseState<TFields, TData>
    {
        public readonly TFields Fields;
        public readonly TData Data;

        protected BaseState(TFields fields, TData data)
        {
            Fields = fields;
            Data = data;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
