using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Billiards
{
    public sealed class CueBall : Ball
    {
        [SerializeField] private MeshRenderer _renderer;
        
        [Serializable]
        public class Data
        {
            public Vector3 Position;
            public Color Color;
        }

        [ContextMenu("Save")]
        public void Save()
        {
            var data = new Data()
            {
                Position = transform.position,
                Color = _renderer.material.color,
            };
            UserSettings.SaveBall(data);
        }

        [ContextMenu("Load")]
        public void Load()
        {
            var data = UserSettings.LoadBall();
            transform.position = data.Position;
            _renderer.material.color = data.Color;
        }
    }
}