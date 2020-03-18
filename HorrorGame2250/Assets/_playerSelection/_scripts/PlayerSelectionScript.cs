using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionScript : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
