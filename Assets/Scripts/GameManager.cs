using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameState {Start, Play, Over, Pause, SelectPlayer, SelectStage};

public class GameManager : MonoBehaviour 
{
	public GameObject MainMenu;
	public GameObject PauseMenu;
	public GameObject Controls;
	public GameObject GameOverMenu;

	private GameState state;

	// Use this for initialization
	void Start () 
	{
		state = GameState.Start;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Menu Button states
	public void PlayButtonDidPress() 
	{
		state = GameState.Play;
		MainMenu.SetActive(false);
		PauseMenu.SetActive(false);
		Controls.SetActive(true);
		GameOverMenu.SetActive(false);	
	}

	public void PauseButtonDidPress()
	{
		state = GameState.Pause;
		MainMenu.SetActive(false);
		PauseMenu.SetActive(true);
		Controls.SetActive(false);
		GameOverMenu.SetActive(false);	
	} 

	public void ResumeButtonDidPress()
	{
		state = GameState.Play;
		MainMenu.SetActive(false);
		PauseMenu.SetActive(false);
		Controls.SetActive(true);
		GameOverMenu.SetActive(false);	
	}

	public void QuitButtonDidPress() 
	{
		state = GameState.Over;
		MainMenu.SetActive(true);
		PauseMenu.SetActive(false);
		Controls.SetActive(false);
		GameOverMenu.SetActive(true);	
	}
}
