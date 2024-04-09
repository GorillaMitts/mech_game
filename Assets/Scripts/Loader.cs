using System;
using UnityEngine.SceneManagement;

public static class Loader
{

    public enum Scene
    {
        Gameplay,
        Loading,
        MainMenu
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene)
    {




        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());

        };

        SceneManager.LoadScene(Scene.Loading.ToString());

    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
