using UnityEngine;
using System.Collections;
using System.Collections.Generic;		
using UnityEngine.UI;					
	
	public class GameManager : MonoBehaviour
	{
		public float levelStartDelay = 2f;						
		public float turnDelay = 0.1f;												
		public static GameManager instance = null;							
		private Text levelText;									
		private GameObject levelImage;							
		private BoardManager boardScript;						
		private int level = 1;																				
		private bool doingSetup = true;							
		
		void Awake()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);	
			DontDestroyOnLoad(gameObject);
			boardScript = GetComponent<BoardManager>();
			InitGame();
		}
		
		void OnLevelWasLoaded(int index)
		{
			level++;
			InitGame();
		}
		
		void InitGame()
		{
			doingSetup = true;	
			levelImage = GameObject.Find("LevelImage");
			levelText = GameObject.Find("LevelText").GetComponent<Text>();
			levelText.text = "Day " + level;
			levelImage.SetActive(true);
			Invoke("HideLevelImage", levelStartDelay);
			boardScript.SetupScene(level);
		}

		void HideLevelImage()
		{
			levelImage.SetActive(false);	
			doingSetup = false;
		}
		
		void Update()
		{
			
		}
		
		public void GameOver()
		{
			levelText.text = "After " + level + " days, you starved.";
			levelImage.SetActive(true);
			enabled = false;
		}
	}


