using UnityEngine;

namespace MIG.API
{
    public interface IWindowSettings
    {
        GameObject GetWindowPrefab(WindowType windowType);
    }
}
