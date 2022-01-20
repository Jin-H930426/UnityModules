using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule
{
    public class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        ///singleton instance
        protected static T m_singleton = null;

        public static T singleton
        {
            get
            {
                init();
                return m_singleton;
            }
        }

        protected virtual void Awake() {
            init();
        }
        /// Initalized singleton
        protected static void init()
        {
            if (!m_singleton)
            {
                m_singleton = FindObjectOfType<T>();
                if (!m_singleton)
                {
                    m_singleton = new GameObject($"{typeof(T)}").AddComponent<T>();
                    m_singleton.transform.position = Vector3.zero;
                    m_singleton.transform.rotation = Quaternion.identity;
                }
            }
        }

        protected virtual void OnDestroy()
        {
            m_singleton = null;
        }
    }
}