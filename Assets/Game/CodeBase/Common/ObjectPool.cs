using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.CodeBase.Common
{
    public class ObjectPool<T> where T: MonoBehaviour
    {
        private LinkedList<T> _pooledObjets;

        public ObjectPool()
        {
            _pooledObjets = new LinkedList<T>();
        }
        
        public T GetFromPool()
        {
            if (_pooledObjets.Count == 0)
                return null;
            
            T result = _pooledObjets.First();
            result.gameObject.SetActive(true);
            _pooledObjets.Remove(result);
            
            return result;
        }

        public void ReturnToPool(T objectToReturn) 
        {
            objectToReturn.gameObject.SetActive(false);
            _pooledObjets.AddFirst(objectToReturn);
        }
    }
}