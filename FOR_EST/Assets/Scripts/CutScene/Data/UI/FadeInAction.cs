using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class FadeInAction : BaseAction
    {
        public FadeInAction()
        {
            _actionType = EActions.FadeIn;
        }
        public float time;
    }
}