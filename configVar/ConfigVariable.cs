using System;

namespace configVar
{
    public interface IConfigVar
    {
        object GetData();
        string GetName();
        void SetValue(object val);
        Type GetValueType();
    }

    class CVar<T> : IConfigVar
    {
        string _name;
        T _val;

        public CVar(string name, T val)
        {
            _name = name;
            _val = val;
            ConfigRegistry.Register(this);
        }

        public object GetData() { return _val; }

        public T GetValue() { return _val; }
        public string GetName() { return _name; }
        public void SetValue(object val) { _val = (T)val; }

        public Type GetValueType() { return _val.GetType(); }
    }
}
