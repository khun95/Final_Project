using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RitualController : MonoBehaviour
{
    public int mapNums;
    public GameObject panel;
    public TextMeshProUGUI tmpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SceneChange()
    {
        if (mapNums == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (mapNums == 1)
        {
            SceneManager.LoadScene(0);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
