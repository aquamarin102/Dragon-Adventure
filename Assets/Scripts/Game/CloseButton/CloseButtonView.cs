using UnityEngine;
using UnityEngine.UI;


namespace Game.CloseButton
{
    internal class CloseButtonView : MonoBehaviour
    {
        [field: SerializeField] public Button CloseButton { get; private set; }
    }
}