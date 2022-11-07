
using Tool.Interfaces;
using UnityEngine;

namespace Game.Players
{
    internal abstract class TransportController : BaseController, IAbilityActivator
    {
        public abstract GameObject ViewGameObject { get; }
        public abstract TransportModel TransportModel { get; }
        
    }
}