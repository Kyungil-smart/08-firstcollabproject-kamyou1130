using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CharacterMoveAction : BaseAction
    {
        public CharacterMoveAction()
        {
            _actionType = EActions.CharacterMove;
        }
        public string character;
        public Vector2 position;
    }
}