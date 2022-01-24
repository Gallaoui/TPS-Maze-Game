using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] private Movements mv;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject WinBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            animator.SetBool("winState", true);
            mv.OnDisable();
            WinBar.SetActive(true);
        }
    }
}
