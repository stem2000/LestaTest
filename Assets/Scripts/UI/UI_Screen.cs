using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game_UI
{
    public class UI_Screen : MonoBehaviour
    { 
        public UnityEvent OnScreenStart;
        public UnityEvent OnScreenClose;


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

