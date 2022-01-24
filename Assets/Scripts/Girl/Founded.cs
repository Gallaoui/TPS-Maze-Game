using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Founded : MonoBehaviour
{
    private bool isFounded;
    [SerializeField] Movements PlayerSpeed;
    [SerializeField] Animator animator;
    [SerializeField] Animator Playeranimator;
    [SerializeField] AudioSource cry;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject BarStatus;

    float speedCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            isFounded = true;
            animator.SetBool("Finded", isFounded);
            cry.Stop();
            Playeranimator.SetBool("isWaving", true);
            StartCoroutine(ReturnState());
            
        }
    }

    private void Update()
    {

        if (isFounded)
        {
            agent.destination = Player.transform.position;
        }

        if (PlayerSpeed.speed <= 0f)
        {
            animator.SetFloat("Speed", 0f);
            agent.stoppingDistance = 6f;
        }

        if (PlayerSpeed.speed > 0f)
        {
            animator.SetFloat("Speed", 1f);
        }
    }

    IEnumerator ReturnState()
    {
        yield return new WaitForSeconds(2f);
        Playeranimator.SetBool("isWaving", false);
        this.BarStatus.GetComponent<BoxCollider>().enabled = false;
    }
}
