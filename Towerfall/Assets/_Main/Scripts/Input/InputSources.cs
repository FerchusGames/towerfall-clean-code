using System;
using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    IObservable<Unit> JumpStartAction { get; }
    IObservable<float> MoveAction { get; }
    IObservable<Vector2> DashStartAction { get; }
}
