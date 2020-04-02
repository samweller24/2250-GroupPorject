using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionScript : MonoBehaviour
{
    private readonly string selectedCharacter = "SelectedCharacter";

    public void ScoutSelect()
    {
        PlayerPrefs.SetInt(selectedCharacter, 1);
    }

    public void NormalSelect()
    {
        PlayerPrefs.SetInt(selectedCharacter, 2);
    }

    public void TankSelect()
    {
        PlayerPrefs.SetInt(selectedCharacter, 3);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
