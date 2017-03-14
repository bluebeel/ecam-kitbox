using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    public static ScenesManager Instance;
    // Use this for initialization

	void Start () {
	}
    // Update is called once per frame
    void Update () {
    }

    public void OnChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }

	public static void OnChanges(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
