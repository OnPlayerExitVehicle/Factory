using UnityEngine;

namespace Base
{
    public abstract class BaseObject : MonoBehaviour
    {
        public virtual void ObjectAwake(){}
        
        public virtual void ObjectStart(){}
        
        public virtual void ObjectUpdate(){}
        
        public virtual void ObjectFixedUpdate(){}
        
        public virtual void ObjectLateUpdate(){}
    }
}