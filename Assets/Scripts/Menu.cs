using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject holder,loadscreen;
    private void Start()
    {
       
    }

    public void start()
    {
        SceneManager.LoadScene(1);
       
      
        Debug.Log("Game palying");
    }
  private void loadscreenmode()
    {
        loadscreen.SetActive(false);
    }
  
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
  
    
}
