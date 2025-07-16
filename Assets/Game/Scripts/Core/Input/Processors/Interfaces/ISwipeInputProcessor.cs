public interface ISwipeInputProcessor : IInputProcessor
{
    event System.Action<SwipeDirection> Swipe;

    public enum SwipeDirection
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3,
    }
}