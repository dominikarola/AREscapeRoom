using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSamples : MonoBehaviour
{
   private ParticleSystem ps;

   void Start()
   {

      ps = GetComponent<ParticleSystem>();
      StartCoroutine(SampleParticleRoutine());
   }

   IEnumerator SampleParticleRoutine()
   {
      var main = ps.main;
      main.simulationSpeed = 0.1f;
      ps.Play();
      yield return new WaitForSeconds(.1f);
      main.simulationSpeed = .01f;
   }
}
