using System;
using System.Collections.Generic;
using System.Globalization;

namespace configVar
{
    /// <summary>
    /// ConfigRegistry
    /// </summary>
    class ConfigRegistry
    {
        static ConfigRegistry _inst;

        Dictionary<int, IConfigVar> _configVars = new Dictionary<int, IConfigVar>();

        static void Init()
        {
            if (_inst == null)
                _inst = new ConfigRegistry();
        }

        static public void Set(string name, string value)
        {
            Init();
            _inst.InternalSetValue(name, value);
        }

        static public void Dump()
        {
            Init();
            foreach (IConfigVar var in _inst._configVars.Values)
                Console.WriteLine(var.GetName() + ": " + var.GetData().ToString());
        }

        static public void Register(IConfigVar var)
        {
            Init();
            _inst.InternalRegister(var);
        }

        void InternalRegister(IConfigVar var)
        {
            IConfigVar exists = FindVar(var.GetName().GetHashCode());
            if (exists == null)
                _configVars.Add(var.GetName().GetHashCode(), var);
        }

        void InternalSetValue(string name, string value)
        {
            IConfigVar var = FindVar(name.GetHashCode());

            if (var != null)
            {
                object convertedVal =  Convert.ChangeType(value, var.GetValueType(), CultureInfo.InvariantCulture);
                if (convertedVal != null)
                    var.SetValue(convertedVal);
            }
        }

        IConfigVar FindVar(int key)
        {
            if (_configVars.ContainsKey(key))
                return _configVars[key];

            return null;
        }
    }
}
