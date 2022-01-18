using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RitualController : MonoBehaviour
{
    [SerializeField] int mapNums;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI tmpText;
    // Start is called before the first frame update
    public void SceneChange()
    {
        if (mapNums == 0)
        {
            SceneManager.LoadScene(2);
        }
        else if (mapNums == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void CancleBoard()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (mapNums == 0)
            {
                tmpText.text = "Enter the Dungeon?";
            }
            else if (mapNums == 1)
            {
                tmpText.text = "Exit the Dungeon?";
            }
            panel.SetActive(true);
        }
    }

}
