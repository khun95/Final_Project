using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnloadSceneStreamingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string targetSceneName;
    [SerializeField]
    string triggerOwnScene;
    IEnumerator UnloadStreamingScene()
    {
        var targetScene = SceneManager.GetSceneByName(targetSceneName);
        if (targetScene.isLoaded)
        {
            var currentScene = SceneManager.GetSceneByName(triggerOwnScene);
            SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("GameController"), currentScene);

            var op = SceneManager.UnloadSceneAsync(targetSceneName);
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
            StartCoroutine(UnloadStreamingScene());
        }
    }
}
