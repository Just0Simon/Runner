using UnityEngine;

public class PlayerJumpComponent : MonoBehaviour
{
    private TouchInputProcessor _touchProcessor;
    
    public void Initialize(TouchInputProcessor touchProcessor)
    {
        _touchProcessor = touchProcessor;
    }

    private void Update()
    {
        
    }
}