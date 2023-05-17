using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    private List<AsyncOperation> loadOperations = new List<AsyncOperation>();

    public bool isLoading { get; private set; }

    private void Awake()
    {
        if(!IsSceneActive("Game") && IsSceneActive("StaticManagers"))
        {
            LoadSceneAsync("Game");
        }
    }
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        isLoading = true;
        loadOperations.Add(asyncOp);

        while (!asyncOp.isDone)
        {
            yield return null;
        }

        isLoading = false;
    }

    public void UnloadSceneAsync(string sceneName)
    {
        StartCoroutine(UnloadSceneAsyncCoroutine(sceneName));
    }

    private IEnumerator UnloadSceneAsyncCoroutine(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!scene.isLoaded)
            yield break;

        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(sceneName);
        isLoading = true;
        loadOperations.Add(asyncOp);

        while (!asyncOp.isDone)
        {
            yield return null;
        }

        isLoading = false;
    }

    public bool IsSceneActive(string sceneName)
    {
        Scene activeScene = SceneManager.GetActiveScene();

        return activeScene.name == sceneName;
    }

    private void Update()
    {
        if (loadOperations.Count == 0)
            return;

        float totalProgress = 0f;

        foreach (var operation in loadOperations)
        {
            totalProgress += operation.progress;
        }

        totalProgress /= loadOperations.Count;

        if (totalProgress >= 0.9f)
        {
            loadOperations.Clear();
        }
    }
}