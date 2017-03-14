using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void SignIn()
	{
		var email = GameObject.Find ("EmailInput").GetComponent<InputField> ().text;
		var pwd = GameObject.Find ("PasswordInput").GetComponent<InputField> ().text;
		Person person = StateManager.Instance.company.PersonManager.SelectPerson("customer", email, pwd);
		if (person != null) 
		{
			StateManager.Instance.person = person;
			ScenesManager.OnChanges ("Intro");
		} 
		else 
		{
			Debug.Log ("error");
			GameObject.Find ("SignInEmailErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
			GameObject.Find ("SignInPasswordErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
		}
	}

	public void SignUp()
	{
		var name = GameObject.Find ("NameInput").GetComponent<InputField> ().text;
		var email = GameObject.Find ("EmailInput").GetComponent<InputField> ().text;
		var address = GameObject.Find ("AddressInput").GetComponent<InputField> ().text;
		var phone = GameObject.Find ("PhoneInput").GetComponent<InputField> ().text;
		var pwd = GameObject.Find ("PasswordInput").GetComponent<InputField> ().text;
		Person person = new Person ("customer", name, address, phone, email, pwd);
		person = StateManager.Instance.company.PersonManager.InsertPerson(person);
		if (person != null) 
		{
			StateManager.Instance.person = person;
			ScenesManager.OnChanges ("Intro");
		} 
		else
		{
			Debug.Log ("error");
			GameObject.Find ("SignInEmailErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
			GameObject.Find ("SignInNameErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
			GameObject.Find ("SignInPhoneErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
			GameObject.Find ("SignInAddressErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
			GameObject.Find ("SignInPasswordErrorPanel").GetComponent<Image> ().color = new Color(227, 78, 103, 1);
		}
	}
}
