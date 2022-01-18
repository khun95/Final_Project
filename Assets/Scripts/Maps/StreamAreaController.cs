using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StreamAreaController : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] private string loadSceneName;
    [SerializeField] string sendObjScene;

    bool isLoaded;
    IEnumerator StreamingTargetScene()
    {
        var targetScene = SceneManager.GetSceneByName(loadSceneName);
        if (!targetScene.isLoaded)
        {
            var op = SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
            
            //PlayerController.isLoaded = true;
            while (!op.isDone)
            {
                yield return null;
            }
        }
    }

    IEnumerator UnloadStreamingScene()
    {
        var targetScene = SceneManager.GetSceneByName(loadSceneName);
        if (targetScene.isLoaded)
        {
            var currentScene = SceneManager.GetSceneByName(sendObjScene);

            //for(int i=0;i<SceneManager.sceneCount;i++)
            //{
            //    if(SceneManager.GetActiveScene() != SceneManager.GetSceneAt(i))
            //    {
            //        currentScene= SceneManager.GetSceneAt(i);
            //    }
            //}

          //  Debug.Log(currentScene.name);
            SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("GameController"), currentScene);

            var op = SceneManager.UnloadSceneAsync(loadSceneName);
            //PlayerController.isLoaded = false;
            while (!op.isDone)
            {
                yield return null;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(StreamingTargetScene());
        }
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            StartCoroutine(UnloadStreamingScene());
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
