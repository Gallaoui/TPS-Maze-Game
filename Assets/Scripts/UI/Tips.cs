using System.Collections;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [SerializeField] private GameObject Tip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Tip.SetActive(true);
            StartCoroutine(ReturnState());
        }
    }

    IEnumerator ReturnState()
    {
        yield return new WaitForSeconds(3f);
        Tip.SetActive(false);
    }
}
