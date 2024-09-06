using System;
using UnityEngine;

namespace GameCore.ScaleObject
{
    public class ScalableObject : MonoBehaviour
    {
        [SerializeField] private Transform model;

        private float[] scaleLevels = new[] { 0.5f, 1f, 2f };

        private int currentScaleLevel = 1;

        private void OnEnable()
        {
            if (model == null) model = this.transform;
        }

        public void ScaleUp()
        {
            currentScaleLevel = Mathf.Clamp(currentScaleLevel + 1, 0, scaleLevels.Length);
            UpdateScale();
        }

        public void ScaleDown()
        {
            currentScaleLevel = Mathf.Clamp(currentScaleLevel - 1, 0, scaleLevels.Length);
            UpdateScale();
        }

        private void UpdateScale()
        {
            model.localScale = Vector3.one * scaleLevels[currentScaleLevel];
        }
    }
}