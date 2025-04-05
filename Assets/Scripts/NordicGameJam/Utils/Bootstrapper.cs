using UnityEngine;

namespace NordicGameJam.Utils
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute()
        {
            var managers = Resources.Load("Global Managers");
            var managersInstance = Object.Instantiate(managers);
            Object.DontDestroyOnLoad(managersInstance);
        }
    }
}