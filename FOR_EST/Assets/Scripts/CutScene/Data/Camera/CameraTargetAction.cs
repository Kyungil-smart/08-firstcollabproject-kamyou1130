using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CameraTargetAction : BaseAction
    {
        public CameraTargetAction()
        {
            _actionType = EActions.CameraSetTarget;
        }
        public string Target;
    }
}