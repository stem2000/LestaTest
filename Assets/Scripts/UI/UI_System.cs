using UnityEngine;
using UnityEngine.Events;

namespace Game_UI
{
    public class UI_System : MonoBehaviour
    {
        [Header("System Events")]
        public UnityEvent OnSwitchedScreen = new UnityEvent();

        [SerializeField] private UI_Screen _startScreen;

        private Component[] _screens =  new Component[0];

        private UI_Screen _currentScreen;
        private UI_Screen _previousScreen;
        public UI_Screen CurrentScreen {get {return _currentScreen;} }
        public UI_Screen PreviousScreen { get { return _previousScreen; } }

        private void Start()
        {
            _screens = GetComponentsInChildren<UI_Screen>(true);

            //InitializeScreens();

            if(_startScreen)
                SwitchScreen(_startScreen);
        }

        public void SwitchScreen(UI_Screen screen)
        {
            if (screen)
            {
                if (_currentScreen)
                {
                    _currentScreen.CloseScreen();
                    _previousScreen = _currentScreen;
                }

                _currentScreen = screen;
                _currentScreen.gameObject.SetActive(true);
                _currentScreen.StartScreen();
            }

            OnSwitchedScreen?.Invoke();
        }

        public void GoToPreviousScreen()
        {
            if (_previousScreen)
                SwitchScreen(_previousScreen);
        }

        public void InitializeScreens()
        {
            foreach(var screen in _screens)
            {
                screen.gameObject.SetActive(true);
            }
        }

    }
}

