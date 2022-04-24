using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core.UI
{ 
    public class LoadingAnimationFinisher : MonoBehaviour
    {
        public bool Finished { get; set; } = false;

        public void FinishLoadingAnimation()
        {
            Finished = true;
        }

        public void ResetAnimation()
        {
            Finished = false;
        }
    }
}

