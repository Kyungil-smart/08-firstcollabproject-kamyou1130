using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class DelayAction : BaseAction
    {
        public DelayAction()
        {
            _actionType = EActions.BackgroundImage;
        }

        public float delayTime;
    }
}