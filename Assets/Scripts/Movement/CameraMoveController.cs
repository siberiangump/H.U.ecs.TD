using UnityEngine;
using UnityEngine.Events;
using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MainLogic;
using UnityEngine.AI;

namespace Assets.Scripts.Movement
{
    class CameraMoveController : MonoBehaviour
    {        
        [SerializeField] private Camera MainCamera;
        [SerializeField] private float CameraMoveSpeed = 2.0f;  

        private Transform HeroTransform;
        private Transform CameraTr;       

        private void Awake()
        {
            CameraTr = MainCamera.transform;
        }

        private void LateUpdate()
        {
            FillHeroTransform();

            if (HeroTransform == null)
                return;            

            Vector3 heroPos = new Vector3(HeroTransform.position.x, CameraTr.position.y, HeroTransform.position.z);
            CameraTr.position = Vector3.Lerp(CameraTr.position, heroPos, CameraMoveSpeed * Time.deltaTime);          
        }

      
        private void FillHeroTransform()
        {
            if (HeroTransform == null)
            {
                HeroTransform = GameContext.GetInstance<Transform>(Constants.HeroTransform);                
            }
        }  
    }
}
