using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CameraMoveAction : BaseAction
    {
        public CameraMoveAction()
        {
            _actionType = EActions.CameraMove;
        }
        public Vector2 position;
    }
}