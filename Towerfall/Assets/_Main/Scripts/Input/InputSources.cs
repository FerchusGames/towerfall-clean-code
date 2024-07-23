using System;
using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    IObservable<Unit> Jump { get; }
    IObservable<float> Move { get; }
}
