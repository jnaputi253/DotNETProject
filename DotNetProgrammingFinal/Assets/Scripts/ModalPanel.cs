using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {
	public Text question;
	public Image imageIcon;
	public Button answerAButton;
	public Button answerBButton;
	public Button answerCButton;
	public Button answerDButton;
	public string answer;
	public GameObject modalPanelObject;

	private static ModalPanel modalPanelInstance;

	public static ModalPanel Instance() {
		if(!modalPanelInstance) {
			modalPanelInstance = FindObjectOfType (typeof (ModalPanel)) as ModalPanel;
			if(!modalPanelInstance) {
				Debug.Log ("There needs to be one active ModalPanel script on a GameObject in your scene");
			}
		}

		return modalPanelInstance; 
	}

	// Button handling events below.
	public void Choice(string question, UnityAction answerA, UnityAction answerB, UnityAction answerC, UnityAction answerD) {
		modalPanelObject.SetActive (true);

		answerAButton.onClick.RemoveAllListeners ();
		answerAButton.onClick.AddListener (answerA);
		answerAButton.onClick.AddListener (ClosePanel);

		answerBButton.onClick.RemoveAllListeners ();
		answerBButton.onClick.AddListener (answerB);
		answerBButton.onClick.AddListener (ClosePanel);

		answerCButton.onClick.RemoveAllListeners ();
		answerCButton.onClick.AddListener (answerC);
		answerCButton.onClick.AddListener (ClosePanel);

		answerDButton.onClick.RemoveAllListeners ();
		answerDButton.onClick.AddListener (answerD);
		answerDButton.onClick.AddListener (ClosePanel);

		this.question.text = question;

		// SET THAT ICON IMAGE NAO!!!  GET THAT DOGGY IN HERE!!
		imageIcon.gameObject.SetActive (false);
		answerAButton.gameObject.SetActive (true);
		answerBButton.gameObject.SetActive (true);
		answerCButton.gameObject.SetActive (true);
		answerDButton.gameObject.SetActive (true);
	}

	void ClosePanel() {
		modalPanelObject.SetActive (false);
	}
}
