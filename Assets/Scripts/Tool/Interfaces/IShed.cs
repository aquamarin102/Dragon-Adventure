using UnityEngine.Events;

namespace Tool.Interfaces
{
    internal interface IShedView
    {
        void Init(UnityAction apply, UnityAction back);
        void Deinit();
    }
    
    internal interface IShedController
    {
    }
}