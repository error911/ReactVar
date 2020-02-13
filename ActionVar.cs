using System;
using UnityEngine;

namespace GGTools
{
    public class ActionInt : ActionVar<int> { public ActionInt(int t) : base(t) { } public ActionInt() { } }
    public class ActionUInt : ActionVar<uint> { public ActionUInt(uint t) : base(t) { } public ActionUInt() { } }
    public class ActionFloat : ActionVar<float> { public ActionFloat(float t) : base(t) { } public ActionFloat() { } }
    public class ActionDouble : ActionVar<double> { public ActionDouble(double t) : base(t) { } public ActionDouble() { } }
    public class ActionBool : ActionVar<bool> { public ActionBool(bool t) : base(t) { } public ActionBool() { } }
    public class ActionVector2 : ActionVar<Vector2> { public ActionVector2(Vector2 t) : base(t) { } public ActionVector2() { } }
    public class ActionVector3 : ActionVar<Vector3> { public ActionVector3(Vector3 t) : base(t) { } public ActionVector3() { } }
    public class ActionVector2Int : ActionVar<Vector2Int> { public ActionVector2Int(Vector2Int t) : base(t) { } public ActionVector2Int() { } }
    public class ActionVector3Int : ActionVar<Vector3Int> { public ActionVector3Int(Vector3Int t) : base(t) { } public ActionVector3Int() { } }

    public class ActionVar<T>
    {
        public T Value
        {
            get => _Value;
            set
            {
                _Value = value;
                action?.Invoke(value);
            }
        }

        private T _Value;

        Action<T> action { get; set; }
        //event EventHandler<T> action;// { get; set; }

        #region === Публичные методы ===

        /// <summary>
        /// Подписаться
        /// </summary>
        /// <param name="action"></param>
        public ActionVar<T> Subscribe(Action<T> action)
        {
            this.action += action;
            return this;
        }

        /// <summary>
        /// Принудительно вызвать событие
        /// </summary>
        public ActionVar<T> Call()
        {
            if (_Value == null) action?.Invoke(default);
            else action?.Invoke(_Value);
            return this;
        }

        /// <summary>
        /// Отписаться
        /// </summary>
        /// <param name="action"></param>
        public ActionVar<T> Unsubscribe(Action<T> action)
        {
            this.action -= action;
            return this;
        }

        /// <summary>
        /// Отписаться от всех событий
        /// </summary>
        public ActionVar<T> UnsubscribeAll()
        {
            this.action = null;
            return this;
        }

        #endregion

        #region Конструкторы
        public ActionVar(T t)
        {
            _Value = t;
        }


        public ActionVar()
        {
        }
        #endregion

    }
}
