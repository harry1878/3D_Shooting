using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private UnityEngine.AI.NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        if (nav.enabled)
            nav.SetDestination(player.position);
    }

}
