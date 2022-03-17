using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Button _buttonRestart;

    private void Start()
    {
        _buttonRestart.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void NextLevel()
    {

    }
}
