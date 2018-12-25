using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    class GridSettings : MonoBehaviour
    {
        [SerializeField] public GridData Settings;        

        [System.Serializable]
        public class GridData
        {
            public float RowsDisplacment = 1;
            public float ColumsDisplacment = 1;
        }
    }
}
