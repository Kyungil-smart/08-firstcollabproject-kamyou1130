using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class BaseAction
    {
        [SerializeField] protected EActions _actionType;
        public EActions actionType => _actionType; 
        
        private ENextActionType nextType; 
    }
}   