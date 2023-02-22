using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.CodeBase.Common
{
    public class ObjectPool<T> where T: MonoBehaviour
    {
        private List<T> _pooledObjets;

        public ObjectPool()
        {
            _pooledObjets = new List<T>();
        }
        
        public T GetFromPool() 
        {
            var result = _pooledObjets.FirstOrDefault(o => o.gameObject.activeSelf == false);
            if (result != null)
            {
                result.gameObject.SetActive(true);
                _pooledObjets.Remove(result);
            }
            return result;
        }

        public void ReturnToPool(T objectToReturn) 
        {
            objectToReturn.gameObject.SetActive(false);
            _pooledObjets.Add(objectToReturn);
        }
    }
}