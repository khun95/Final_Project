using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStreamingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string targetSceneName;
    [SerializeField] string triggerOwnScene;

    bool isLoaded;
    IEnumerator StreamingTargetScene()
    {
        var targetScene = SceneManager.GetSceneByName(targetSceneName);
        if (!targetScene.isLoaded)
        {
            var op = SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive);
            PlayerController.isLoaded = true;
            while (!op.isDone)
            {
                yield return null;
            }
        }
    }

    IEnumerator UnloadStreamingScene()
    {
        var targetScene = SceneManager.GetSceneByName(targetSceneName);
        if (targetScene.isLoaded)
        {
            var currentScene = SceneManager.GetSceneByName(triggerOwnScene);
            SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("GameController"), currentScene);
            
            var op = SceneManager.UnloadSceneAsync(targetSceneName);
            PlayerController.isLoaded = false;
            while (!op.isDone)
            {
                yield return null;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            var dir = Vector3.Angle(transform.forward, other.transform.position - transform.position);
            Debug.Log(PlayerController.isLoaded);
            if (!PlayerController.isLoaded)
            {

                StartCoroutine(StreamingTargetScene());
            }
            else
            {
                StartCoroutine(UnloadStreamingScene());
            }
        }
    }
}
