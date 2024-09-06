using System;
using GameCore;
using GameCore.ScaleObject;
using UnityEngine;

namespace Character
{
    public class ScaleObjectAbility : MonoBehaviour
    {
        private LayerMask scalableLayer;
        
        private void OnEnable()
        {
            GameInput.Instance.OnMouseRightAction += OnMouseRight;
            GameInput.Instance.OnMouseLeftAction += OnMouseLeft;
        }

        private void OnDisable()
        {
            GameInput.Instance.OnMouseRightAction -= OnMouseRight;
            GameInput.Instance.OnMouseLeftAction -= OnMouseLeft;
        }
        
        private void OnMouseRight(object o, EventArgs e)
        {
            GetScalableObject()?.ScaleUp();
        }

        private void OnMouseLeft(object o, EventArgs e)
        {
            GetScalableObject()?.ScaleDown();
        }

        private ScalableObject GetScalableObject()
        {
            Debug.Log("???");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int scalableLayerMask = 1 << LayerMask.NameToLayer("Scalable");
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, scalableLayerMask))
            {
                Debug.Log("First Scalable object hit: " + hit.collider.gameObject.name);
                return hit.collider.gameObject.GetComponent<ScalableObject>();
            }

            return null;
        }
    }
}