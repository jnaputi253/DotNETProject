using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour {
	private ModalPanel _modalPanel;
	private DisplayManager _displayManager;

	private UnityAction _answerA;
	private UnityAction _answerB;
	private UnityAction _answerC;
	private UnityAction _answerD;

	void Awake() {
		_modalPanel = ModalPanel.Instance ();
		_displayManager = DisplayManager.Instance ();

		_answerA = new UnityAction (AnswerA);
		_answerB = new UnityAction (AnswerB);
		_answerC = new UnityAction (AnswerC);
		_answerD = new UnityAction (AnswerD);
	}

	public void TestYNC ()
	{
		_modalPanel.Choice ("Do you want to spawn this sphere?", AnswerA, AnswerB, AnswerC, AnswerD);
		//      modalPanel.Choice ("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myCancelAction);
	}

	//  These are wrapped into UnityActions
	void AnswerA ()
	{
		_displayManager.DisplayMessage ("Answer A chosen");
	}

	void AnswerB ()
	{
		_displayManager.DisplayMessage ("Answer B chosen");
	}

	void AnswerC ()
	{
		_displayManager.DisplayMessage ("Answer C chosen");
	}

	void AnswerD ()
	{
		_displayManager.DisplayMessage ("Answer D chosen");
	}
}
