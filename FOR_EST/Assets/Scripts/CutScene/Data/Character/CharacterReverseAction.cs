using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CharacterReverseAction : BaseAction
    {
        public CharacterReverseAction()
        {
            _actionType = EActions.CharacterReverse;
        }
        public string character;
    }
}