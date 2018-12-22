using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    public Camera Camera;
    public NavMeshAgent TargetAgent;
    public Button Area;

    private void Awake()
    {
        Area.onClick.AddListener(TryMove);
    }

    // Update is called once per frame
    public void TryMove()
    {
        if (!TargetAgent)
            return;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Input.mousePosition);
        RaycastHit raycastHit;
        bool rayHitSomeThing = Physics.Raycast(ray, out raycastHit);
        Debug.Log(raycastHit.point);
        if (rayHitSomeThing)
            TargetAgent.SetDestination(raycastHit.point);
    }

    public void SetAgent(NavMeshAgent agent)
    {
        TargetAgent = agent;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryMove();
        }
    }
}
