using System;
using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    IObservable<Unit> JumpStart { get; }
    IObservable<float> Move { get; }
    IObservable<Vector2> DashStart { get; }
}
