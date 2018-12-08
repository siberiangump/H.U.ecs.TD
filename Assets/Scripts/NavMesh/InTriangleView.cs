using UnityEngine;
using UnityEngine.Events;
using Unity.Mathematics;
using UnityEngine.U2D;

namespace Assets.Scripts.NavMesh
{
    class InTriangleView : MonoBehaviour
    {
        [SerializeField] private Transform[] Vertices;
        [SerializeField] private Transform Point;
        [SerializeField] private Sprite sprite;

        private void Update()
        {
            IsPointTriangle();  
        }

        [ContextMenu("IsPointTriangle")]
        public void IsPointTriangle()
        {
            float3 a = new float3(Vertices[0].position.x, Vertices[0].position.y, Vertices[0].position.z);
            float3 b = new float3(Vertices[1].position.x, Vertices[1].position.y, Vertices[1].position.z);
            float3 c = new float3(Vertices[2].position.x, Vertices[2].position.y, Vertices[2].position.z);
            float3 p = new float3(Point.position.x, Point.position.y, Point.position.z);
     
            float3 firstLine = b - a;
            float3 secondLine = c - b;
            float3 thirdLine = a - c;

            bool firstCheck = IsSame(firstLine, secondLine, p - a);
            bool secondCheck = IsSame(secondLine,thirdLine , p - b);
            bool thirdCheck = IsSame(thirdLine,firstLine, p - c);

            bool inTriangle = firstCheck && secondCheck && thirdCheck; 
        }

        private bool IsSame(float3 firstTringleLine, float3 secondTriangleLine, float3 targetLine)
        {
            float3 cpFirstTarget = math.cross(firstTringleLine, targetLine);
            //Debug.Log("ba*pa" + crossProductBaPa);

            float3 cpFirstSecond = math.cross(firstTringleLine, secondTriangleLine);
           // Debug.Log("ba*ca" + crossProductBaCa);

            float dot = math.dot(cpFirstTarget, cpFirstSecond);
            return dot > 0;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vertices[2].position, Vertices[0].position);
            Gizmos.DrawLine(Vertices[0].position, Vertices[1].position);
            Gizmos.DrawLine(Vertices[1].position, Vertices[2].position);
          
        }
    }
}
