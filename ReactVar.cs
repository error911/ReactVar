/* 
 * https://github.com/error911/ReactVar
 * Free license: CC BY Murnik Roman
 */

using System;
using UnityEngine;

namespace GGTools   //.ReactVars
{
    public class ReactInt : ReactVar<int> { public ReactInt(int t) : base(t) { } public ReactInt() { } }
    public class ReactUInt : ReactVar<uint> { public ReactUInt(uint t) : base(t) { } public ReactUInt() { } }
    public class ReactFloat : ReactVar<float> { public ReactFloat(float t) : base(t) { } public ReactFloat() { } }
    public class ReactDouble : ReactVar<double> { public ReactDouble(double t) : base(t) { } public ReactDouble() { } }
    public class ReactBool : ReactVar<bool> { public ReactBool(bool t) : base(t) { } public ReactBool() { } }
    public class ReactVector2 : ReactVar<Vector2> { public ReactVector2(Vector2 t) : base(t) { } public ReactVector2() { } }
    public class ReactVector3 : ReactVar<Vector3> { public ReactVector3(Vector3 t) : base(t) { } public ReactVector3() { } }
    public class ReactVector4 : ReactVar<Vector4> { public ReactVector4(Vector4 t) : base(t) { } public ReactVector4() { } }
    public class ReactVector2Int : ReactVar<Vector2Int> { public ReactVector2Int(Vector2Int t) : base(t) { } public ReactVector2Int() { } }
    public class ReactVector3Int : ReactVar<Vector3Int> { public ReactVector3Int(Vector3Int t) : base(t) { } public ReactVector3Int() { } }
    public class ReactColor : ReactVar<Color> { public ReactColor(Color t) : base(t) { } public ReactColor() { } }

    public class ReactVar<T>
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
        public ReactVar<T> Subscribe(Action<T> action)
        {
            this.action += action;
            return this;
        }

        /// <summary>
        /// Принудительно вызвать событие
        /// </summary>
        public ReactVar<T> Call()
        {
            if (_Value == null) action?.Invoke(default);
            else action?.Invoke(_Value);
            return this;
        }

        /// <summary>
        /// Отписаться
        /// </summary>
        /// <param name="action"></param>
        public ReactVar<T> Unsubscribe(Action<T> action)
        {
            this.action -= action;
            return this;
        }

        /// <summary>
        /// Отписаться от всех событий
        /// </summary>
        public ReactVar<T> UnsubscribeAll()
        {
            this.action = null;
            return this;
        }

        #endregion

        #region Конструкторы
        public ReactVar(T t)
        {
            _Value = t;
        }


        public ReactVar()
        {
        }
        #endregion

    }
}
