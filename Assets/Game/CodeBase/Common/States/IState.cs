namespace Game.CodeBase.Common.States
{
    public interface IState<in T>
    {
        void Enter(T payloadData);
        void Exit();
    }
}