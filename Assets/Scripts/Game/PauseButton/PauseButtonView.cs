using UnityEngine;
using UnityEngine.UI;

namespace Game.PauseButton
{
    public class PauseButtonView : MonoBehaviour
    {
        [field: SerializeField] public Button PauseButton { get; private set; }
    }
}