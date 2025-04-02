using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnStateChange += OnStateChange;
        InputManager.OnPause += Pause;  
    }

    private void OnDisable()
    {
        GameManager.OnStateChange -= OnStateChange;
        InputManager.OnPause -= Pause;
    }

    void Pause()
    {
        if(GameManager.CurrentState == GameState.Gameplay)
        {
            GameManager.SwitchState(GameState.Pause);
        }
        else if(GameManager.CurrentState == GameState.Pause)
        {
            GameManager.SwitchState(GameState.Gameplay);
        }
    }

    private void OnStateChange(GameState state)
    {
        if (state == GameState.Pause) 
        {
            UIManager.Instance.SwitchPanel("Pause");
        }
    }
}
