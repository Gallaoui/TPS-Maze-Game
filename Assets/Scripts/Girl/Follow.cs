using UnityEngine.AI;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Founded state;
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField] private GameObject Player;

    bool st;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        /*
        print(st);
        if (state.getState() == true)
        {
            animator.SetBool("Finded", state.getState());

            agent.destination = Player.transform.position;
            agent.stoppingDistance = 6f;
        }*/
            /* if (agent.speed == 0f)
         {
             animator.SetBool("walk", false);
         }*/
    }

}
