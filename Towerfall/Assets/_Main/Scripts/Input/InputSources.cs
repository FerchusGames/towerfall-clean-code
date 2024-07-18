using System;
using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    IObservable<Unit> Jump { get; }
    IObservable<Vector2> Move { get; }
}
