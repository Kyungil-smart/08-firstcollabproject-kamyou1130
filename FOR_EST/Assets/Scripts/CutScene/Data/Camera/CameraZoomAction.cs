using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CameraZoomAction : BaseAction
    {
        public CameraZoomAction()
        {
            _actionType = EActions.CameraZoom;
        }
        public float value = 1.0f;
    }
}