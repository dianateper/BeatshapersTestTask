using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.CodeBase.Common
{
    public class ObjectPool<T> where T: MonoBehaviour
    {
        private List<T> pooledObjets;

        public ObjectPool()
        {
            pooledObjets = new List<T>();
        }
        
        public T GetFromPool() 
        {
            var result = pooledObjets.FirstOrDefault(o => o.gameObject.activeInHierarchy);
            if (result != null)
            {
                result.gameObject.SetActive(true);
                pooledObjets.Remove(result);
            }
            return result;
        }

        public void ReturnToPool(T objectToReturn) 
        {
            objectToReturn.gameObject.SetActive(false);
            pooledObjets.Add(objectToReturn);
        }
    }
}