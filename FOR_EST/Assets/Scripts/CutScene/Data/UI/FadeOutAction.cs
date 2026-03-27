using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class FadeOutAction : BaseAction
    {
        public FadeOutAction()
        {
            _actionType = EActions.FadeOut;
        }
        public float time;
    }
}