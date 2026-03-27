using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class BackgroundImageAction : BaseAction
    {
        public BackgroundImageAction()
        {
            _actionType = EActions.BackgroundImage;
        }
        public string image;
    }
}