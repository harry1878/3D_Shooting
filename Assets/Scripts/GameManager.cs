using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public Text resumeText;
    public bool isGameOver = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ActivePanel();
           
        }
        
    }

    public void ActivePanel()
    {
        if (isGameOver)
            resumeText.text = "RE TRY?";
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Resume()
    {
        Time.timeScale = 1;
        if(isGameOver)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            panel.SetActive(false);
        }
    }

}