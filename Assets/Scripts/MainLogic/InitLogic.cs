using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Assets.Scripts.MainLogic
{
    class InitLogic : MonoBehaviour
    {
        [SerializeField] private InnerEvents Events;

        private IEnumerator Start()
        {
            Events.Init.Invoke();
            yield return null;
            Events.OnNextFramAfterInit.Invoke();
        }

        [Serializable]
        private class InnerEvents
        {
            public UnityEvent Init;
            public UnityEvent OnNextFramAfterInit;
        }
    }
}
