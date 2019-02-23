﻿using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace MOP.Controller.Dialogues
{
    public class VariableStorage : VariableStorageBehaviour
    {
        Dictionary<string, Yarn.Value> variables = new Dictionary<string, Yarn.Value>();

        [System.Serializable]
        public class DefaultVariable
        {
            public string name;
            public string value;
            public Yarn.Value.Type type;
        }

        public DefaultVariable[] defaultVariables;

        public override void ResetToDefaults()
        {
            Clear();

            foreach (var variable in defaultVariables)
            {

                object value;

                switch (variable.type)
                {
                    case Yarn.Value.Type.Number:
                        float f = 0.0f;
                        float.TryParse(variable.value, out f);
                        value = f;
                        break;

                    case Yarn.Value.Type.String:
                        value = variable.value;
                        break;

                    case Yarn.Value.Type.Bool:
                        bool b = false;
                        bool.TryParse(variable.value, out b);
                        value = b;
                        break;

                    case Yarn.Value.Type.Variable:
                        // We don't support assigning default variables from other variables
                        // yet
                        Debug.LogErrorFormat("Can't set variable {0} to {1}: You can't " +
                            "set a default variable to be another variable, because it " +
                            "may not have been initialised yet.", variable.name, variable.value);
                        continue;

                    case Yarn.Value.Type.Null:
                        value = null;
                        break;

                    default:
                        throw new System.ArgumentOutOfRangeException();

                }

                var v = new Yarn.Value(value);

                SetValue("$" + variable.name, v);
            }
        }

        public override void SetValue(string variableName, Yarn.Value value)
        {
            variables[variableName] = new Yarn.Value(value);
        }

        public override Yarn.Value GetValue(string variableName)
        {
            if (variables.ContainsKey(variableName) == false)
                return Yarn.Value.NULL;

            return variables[variableName];
        }

        public override void Clear()
        {
            variables.Clear();
        }
    }
}