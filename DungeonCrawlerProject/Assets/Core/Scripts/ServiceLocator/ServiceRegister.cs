using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Core.ServiceLocator
{
    public class ServiceRegister
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Initiailze()
        {
            // Initialize default service locator.
            ServiceLocator.Initiailze();

            // Register all your services next.
            //ServiceLocator.Current.Register<IMyGameServiceA>(new MyGameServiceA());
            //ServiceLocator.Current.Register<IMyGameServiceB>(new MyGameServiceB());
            //ServiceLocator.Current.Register<IMyGameServiceC>(new MyGameServiceC());

            // Application is ready to start, load your main scene.
            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }
}
