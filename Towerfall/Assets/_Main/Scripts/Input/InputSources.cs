using System;
using UniRx;

public interface IPlayerInput
{
    IObservable<Unit> Jump { get; }
}
