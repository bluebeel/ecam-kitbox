using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	public static StateManager Instance;
	public Company company;
	public Person person = null;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		company = new Company ("localhost", "kitbox", "bluebeel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
