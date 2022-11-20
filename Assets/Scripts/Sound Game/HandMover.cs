using System;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

namespace Sound_Game
{
    public class HandMover : MonoBehaviour
    {
        [SerializeField] private GameObject hand;
        [SerializeField] private float moveValue;
        [SerializeField] private float moveDuration = 2;
        [SerializeField] private float moveDownDuration = 1.5f;
        [SerializeField] private float moveDownDelay = 0.5f;
        [SerializeField] private Ease moveEase;
        [SerializeField] private Ease moveDownEase;

        private float _initialPosition;
        public Action OnHandFinishedMoving;
        public Action<Button> OnHandClicked;
        private void Awake() => _initialPosition = transform.localPosition.y;

        public void MoveCatHand(Button button)
        {
            var position = hand.transform.position;
            position = new Vector3(button.transform.position.x, position.y,
                position.z);
            hand.transform.position = position;

            hand.transform.DOLocalMoveY(_initialPosition + moveValue, moveDuration).SetEase(moveEase).OnComplete((() =>
            {
                OnHandClicked?.Invoke(button);
                hand.transform.DOLocalMoveY(_initialPosition, moveDownDuration).SetEase(moveDownEase)
                    .SetDelay(moveDownDelay).OnComplete((
                        () => { OnHandFinishedMoving?.Invoke(); }));
            }));
        }
    }
}