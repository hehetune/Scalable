using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class Npc : MonoBehaviour
    {
        private INpcState _currentState;
        private TutorialState _tutorialState;
        private PostTutorialState _postTutorialState;

        private void Awake()
        {
            _tutorialState = GetComponent<TutorialState>();
            _postTutorialState = GetComponent<PostTutorialState>();
        }

        private bool _tutorialCompleted = false;

        private void Start()
        {
            _currentState = _tutorialState;  // Start with tutorial
        }

        public void CompleteTutorial()
        {
            _tutorialCompleted = true;
            _currentState = _postTutorialState; // Switch to post-tutorial state
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentState.HandleInteraction();
        }

        // private void OnTriggerExit(Collider other)
        // {
        //     
        // }
    }


}