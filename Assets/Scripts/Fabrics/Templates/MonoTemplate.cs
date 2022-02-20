using System;
using Ecs;
using Ecs.View;
using UnityEngine;

namespace Fabrics.Templates
{
    public class MonoTemplate : MonoBehaviour
    {
        [SerializeField] private Template[] monoTemplates;
        

        public ILinkable Get(EMono name)
        {
            foreach (var template in monoTemplates)
            {
                if (template.name == name)
                {
                    var view = template.monoObject.GetComponent<ILinkable>();
                    return view;
                }
            }
            throw new Exception($"MonoTemplate doesn't have object with {name} name");
        }
    }


[Serializable]
    public class Template
    {
        public EMono name;
        public LinkView monoObject;
    }
}