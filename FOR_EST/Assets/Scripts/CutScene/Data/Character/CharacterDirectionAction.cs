using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CharacterDirectionAction : BaseAction
    {
        public CharacterDirectionAction()
        {
            _actionType = EActions.CharacterDirection;
        }
        public string character;
        public bool isLeft;
    }
}