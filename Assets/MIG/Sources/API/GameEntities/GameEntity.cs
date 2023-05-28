using System;
using UnityEngine;

namespace MIG.API
{
    public sealed class GameEntity :
        MonoBehaviour,
        IEquatable<GameEntity>,
        IComparable<GameEntity>
    {
        public int Id { get; private set; }

        public GameObject GameObject => gameObject;

        public void Init(int id)
        {
            Id = id;
        }

        public override string ToString() =>
            $"{gameObject.name} id = {Id}";

        public int CompareTo(GameEntity other) =>
            Id.CompareTo(other.Id);

        public bool Equals(GameEntity other) =>
            Id == other.Id;
    }
}
