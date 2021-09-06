using System;
using System.Collections;
using _EndlessRunnerTestGame.Scripts.Animation;
using _EndlessRunnerTestGame.Scripts.Game;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerCamera playerCameraScript;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PlayerMovement playerMovementScript;
        [SerializeField] private CharacterAnimationManager playerAnimationScript;

        [Header("Player Body")]
        [SerializeField] private GameObject ragdoll;
        [SerializeField] private GameObject model;

        public void ActivatePlayer()
        {
            playerCameraScript.enabled = true;
            playerController.enabled = true;
            playerMovementScript.enabled = true;
            playerAnimationScript.enabled = true;
        }

        private void OnEnable()
        {
            GlobalGameEvents.OnGameStarted += SetupRagdoll;
            GlobalGameEvents.OnGameOver += DisablePlayerOnGameOver;
        }

        private void OnDisable()
        {
            GlobalGameEvents.OnGameStarted -= SetupRagdoll;
            GlobalGameEvents.OnGameOver -= DisablePlayerOnGameOver;
        }

        private void SetupRagdoll()
        {
            ragdoll.transform.position = Vector3.down * 10;
            ragdoll.SetActive(true);
            StartCoroutine(RagdollWaitTillSet(.1f));
        }
        
        private IEnumerator RagdollWaitTillSet(float interval)
        {
            yield return new WaitForSeconds(interval);
            ragdoll.SetActive(false);
            ragdoll.transform.position = model.transform.position;
        }


        private void DisablePlayerOnGameOver()
        {
            playerMovementScript.enabled = false;
            EnableRagdoll();
            StartCoroutine(DisablePlayerInterval(5f));
        }

        private IEnumerator DisablePlayerInterval(float interval)
        {
            yield return new WaitForSeconds(interval);
            gameObject.SetActive(false);
        }

        private void EnableRagdoll()
        {
            // CopyTransformData(model.transform, ragdoll.transform, playerMovementScript.rb.velocity);
            ragdoll.SetActive(true);
            model.SetActive(false);
        }

        private void CopyTransformData(Transform source, Transform destination, Vector3 velocity)
        {
            if (source.childCount != destination.childCount)
            {
                Debug.LogError("Transform Data can not be copied on non matching transforms.");
                return;
            }

            for (int i = 0; i < source.childCount; i++)
            {
                Transform src = source.GetChild(i);
                Transform dst = destination.GetChild(i);
                dst.position = src.position;
                dst.rotation = src.rotation;
                
                Rigidbody dstRigidbody;
                if (!destination.TryGetComponent(out dstRigidbody)) Debug.LogWarning("Destination transform has no Rigidbody.");
                else
                {
                    dstRigidbody.velocity = velocity;
                }
                
                CopyTransformData(src, dst, velocity);
            }
        }
    }
}