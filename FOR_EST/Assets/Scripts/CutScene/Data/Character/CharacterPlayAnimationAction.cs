using UnityEngine;

namespace CutScene
{
    [System.Serializable]
    public class CharacterPlayAnimationAction : BaseAction
    {
        public CharacterPlayAnimationAction()
        {
            _actionType = EActions.CharacterPlayAnimation;
        }
        public string character;
    }
}