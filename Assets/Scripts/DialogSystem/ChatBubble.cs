using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DialogSystem
{
    public class ChatBubble : MonoBehaviour
    {
        private Queue<string> _messageQueue = new();
        [SerializeField] private GameObject _chatBubbleContainer;
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private float messageExistTime = 1f;
        [SerializeField] private float delayBetweenMessage = 0.5f;

        private Coroutine _displayChatBubbleCoroutine;

        public void AddMessage(string[] messages)
        {
            foreach(var msg in messages) _messageQueue.Enqueue(msg);
            StartBubbleChat();
        }

        private IEnumerator DisplayChatBubbleCoroutine()
        {
            while (_messageQueue.Any())
            {
                _messageText.text = _messageQueue.Dequeue();
                _chatBubbleContainer.SetActive(true);
                yield return messageExistTime.Wait();
                _chatBubbleContainer.SetActive(false);
                yield return delayBetweenMessage.Wait();
            }

            _displayChatBubbleCoroutine = null;
        }

        private void StartBubbleChat()
        {
            if (_displayChatBubbleCoroutine != null) return;
            _displayChatBubbleCoroutine = StartCoroutine(DisplayChatBubbleCoroutine());
        }
    }
}