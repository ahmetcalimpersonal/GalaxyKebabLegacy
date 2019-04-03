﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceContainerBehaviour : MonoBehaviour
{
    public enum SpiceType { salt, blackPepper, chiliPepper, mayonnaise, mustard, ketchup }
    public SpiceType spiceType;
    public float amountPerShake;
    public ParticleSystem particleSystem;
    public SkinnedMeshRenderer skinnedMesh;
    public bool isFluid;
    public bool canAdd;
    public void UseIngredient(float amount)
    {

        if (!isFluid)
        {

            if (skinnedMesh.GetBlendShapeWeight(0) >= 10f)
            {
                Debug.Log(skinnedMesh.GetBlendShapeWeight(0));
                skinnedMesh.SetBlendShapeWeight(0, skinnedMesh.GetBlendShapeWeight(0) - amount);
            }
        }
      
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit))
        {
            if (hit.transform != null)
            {
               
                if (hit.transform.tag == "LavasIngredient" && canAdd)
                {
                    GetComponent<IngredientItem>().Action();
                    Debug.Log("Dökülüyor");
                    canAdd = false;
                    
                }
                else
                {
                    
                }
                }
               
            }
            else
            {
                Debug.Log("Dökülemiyor.");
            }
        }
    public void Particle()
    {
        StartCoroutine(ActivateParticle());
    }
    public IEnumerator ActivateParticle()
    {
        particleSystem.Play();
        yield return new WaitForSeconds(1f);
        if (particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }
    }