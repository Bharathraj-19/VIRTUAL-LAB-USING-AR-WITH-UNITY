using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public void quit()
    {
        Application.Quit();
    }
    public void openlink()
    {
        Application.OpenURL("https://github.com/Dasha0712/Virtual-Labarotory-Using-AR.git");
    }
    public void PlayDiodeScene()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayZenerScene()
    {
        SceneManager.LoadScene(2);
    }
    public void returnToList()
    {
        SceneManager.LoadScene(0);
    }
}
