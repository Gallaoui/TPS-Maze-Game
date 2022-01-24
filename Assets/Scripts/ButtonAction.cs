using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
