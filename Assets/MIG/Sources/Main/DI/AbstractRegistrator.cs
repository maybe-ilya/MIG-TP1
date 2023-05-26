using UnityEngine;
using VContainer;

namespace MIG.Main
{
    public abstract class AbstractRegistrator : MonoBehaviour
    {
        public abstract void Register(IContainerBuilder builder);
    }
}
