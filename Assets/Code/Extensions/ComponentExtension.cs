
using System;
using UnityEngine;

namespace Task.Extensions
{
    public static class ComponentExtension
    {
        /// <summary>
        /// Проверяет, что компонент не null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        private static bool ValidateComponent<T>(T component)
        {
            if(component == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет, что компонент не null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="behaviour"></param>
        /// <param name="component"></param>
        public static void ValidateComponent<T>(this MonoBehaviour behaviour, T component)
        {
            if(!ValidateComponent(component))
                throw new NullReferenceException($"Компонент {typeof(T).Name} не найден на {behaviour.name}");
        }

        /// <summary>
        /// Возвращает компонент, который находится в RaycastHit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hit"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static T GetHitComponent<T>(this RaycastHit2D hit)
        {
            T component = hit.transform.GetComponent<T>();
            if(ValidateComponent(component))
                return component;
            else 
                throw new NullReferenceException($"Компонент {typeof(T).Name} не найден на {hit.transform.name}");            
        }

        /// <summary>
        /// Преобразует вектор 2D в вектор 3D
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector3 ToVector3(this Vector2 vector) 
            => new Vector3(vector.x, vector.y, 0);

    }
}

