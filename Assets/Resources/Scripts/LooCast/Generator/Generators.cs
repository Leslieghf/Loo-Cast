using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LooCast.Generator
{
    public class Generators : MonoBehaviour
    {
        public List<Generator> generators;

        public virtual void Initialize()
        {
            generators = GetComponentsInChildren<Generator>().ToList();
            foreach (Generator generator in generators)
            {
                generator.Initialize();
            }
        }
    } 
}
