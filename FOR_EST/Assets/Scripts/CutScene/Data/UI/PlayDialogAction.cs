using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class PlayDialogAction : BaseAction
    {
        public PlayDialogAction()
        {
            _actionType = EActions.PlayDialog;
        }
        public string dialogNumber;
        public string dialogTarget;
        public Vector2 dialogPosition;
    }
}