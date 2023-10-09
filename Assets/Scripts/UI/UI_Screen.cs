using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game_UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UI_Screen : MonoBehaviour
    {
        [SerializeField] private Selectable _startSelectable;

        public UnityEvent OnScreenStart;
        public UnityEvent OnScreenClose;

        private void Start()
        {
            if (_startSelectable)
            {
                EventSystem.current.SetSelectedGameObject(_startSelectable.gameObject);
            }
        }

        public virtual void StartScreen()
        {
            OnScreenStart?.Invoke();
        }

        public virtual void CloseScreen()
        {
            OnScreenClose?.Invoke();
            gameObject.SetActive(false);
        }
    }
}

