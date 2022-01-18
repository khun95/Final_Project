using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }
    public void BaseCampLoad()
    {
        SceneManager.LoadScene(1);
    }
    public void TitleLoad()
    {
        SceneManager.LoadScene(0);
    }
    public void OptionsLoad()
    {
        SceneManager.LoadScene("Options");
    }
    public void ExitLoad()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
