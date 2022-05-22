using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Game.GameManagement
{
    public class Profile : MonoBehaviour
    {
        [SerializeField]
        TMP_Text ProfileName;

        [SerializeField]
        TMP_Text Created;

        public string Name { get; private set; }

        private void Awake()
        {
            Name = ProfileName.text;
        }

    }
}

