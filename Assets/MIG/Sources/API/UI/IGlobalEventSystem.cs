using UnityEngine.EventSystems;

namespace MIG.API
{
    public interface IGlobalEventSystem
    {
        BaseInputModule InputModule { get; }
    }
}
