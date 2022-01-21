using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Resource
{
    using System.Linq;
    [System.Serializable] public class ResourcesManager
    {
        SortedDictionary<string, Object> ResourcesPool = null;

        /// Initialized ResourcesManager
        public void Awake() {
            ResourcesPool = new SortedDictionary<string, Object>();
        }
        /// Destroy ResourcesManager
        public void OnDestroy() {
            ResourcesPool.Clear();
        }

        /// For load at Path
        public T Load<T>(string path) where T : Object{

            if(!ResourcesPool.ContainsKey(path))
            {
                T resource = Resources.Load<T>(path);
                if(resource == null) {
                    Debug.LogError($"Failed to load prefab : {path}");
                    return null;
                }

                ResourcesPool.Add(path, resource);

                if(ResourcesPool.Count > 30)
                {
                      ResourcesPool.Remove(ResourcesPool.Keys.First<string>());
                }
                return resource;
            }
            
            return (T)ResourcesPool[path];
        }
        public T Instantiate<T>(string path, Transform parent = null) where T : Object{
            T prefab = Load<T>(path);
            if(prefab == null) return null;

            return Object.Instantiate<T>(prefab, parent);
        }
        public T Instantiate<T>(string path, Vector2 position, Quaternion rotation, Transform parent = null) where T : Object{
            T prefab = Load<T>(path);
            if(prefab == null) return null;

            return Object.Instantiate<T>(prefab, position, rotation ,parent);
        }
        public GameObject Instantiate(string path, Transform parent = null) {
            GameObject prefab = Load<GameObject>(path);
            if(prefab == null) return null;

            return Object.Instantiate(prefab, parent);
        }
        public GameObject Instantiate(string path, Vector2 position, Quaternion rotation ,Transform parent = null) {
            GameObject prefab = Load<GameObject>(path);
            if(prefab == null) return null;

            return Object.Instantiate(prefab, position, rotation, parent);
        }
        
        public void Destroy(GameObject go)
        {
            if(go) return;

            Object.Destroy(go);
        }
        public void Destroy(GameObject go, float t)
        {
            if(go) return;

            Object.Destroy(go, t);
        }

    }
}