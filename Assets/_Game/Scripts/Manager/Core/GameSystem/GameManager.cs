using System;
using MainraFramework.States;
using UnityEngine;

namespace MainraFramework
{
	public class GameManager : PersistentSingleton<GameManager>
	{
		private GameState currentState;
		
		public SceneManager SceneManager { get; private set; }
		public SaveDataManager SaveDataManager { get; private set; }
		//TODO: Add more manager here

		protected override void Awake()
		{
			base.Awake();
			SceneManager = new SceneManager(this);
			SaveDataManager = new SaveDataManager(this);
			//TODO: Initialize more manager here
		}

		public void SetState(GameState newState)
		{
			if (currentState != null)
				currentState.ExitState(); // Exit the current state

			currentState = newState;

			if (currentState != null)
				currentState.EnterState(); // Enter the new state
		}

		private void Start()
		{
			SaveDataManager.
			SetState(new MainMenuState()); // Set initial state
			
		}

		private void Update()
		{
			if (currentState != null)
			{
				currentState.UpdateState(); // Update the current state
			}
		}
	}
}