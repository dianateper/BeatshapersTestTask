namespace Game.CodeBase.Common.States
{
    public interface IStateSwitcher
    {
        void SwitchState<T>();
    }
}