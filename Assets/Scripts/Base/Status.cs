using System.Collections.Generic;
using Property;

namespace Status
{
    public class FloatProperty : IProperty<float, EProperty>
    {
        EProperty key;
        float value;

        FloatProperty(EProperty key, float value)
        {
            this.key = key;
            this.value = value;
        }

        public new EProperty GetType()
        {
            return this.key;
        }

        public float Value { get { return this.value; } set { this.value = value; } }
    }

    public class Status
    {
        private Dictionary<EProperty, FloatProperty> dic_float_property = new Dictionary<EProperty, FloatProperty>();
    
        public void Set_Property(FloatProperty p)
        {
            if (Is_Property(p.GetType())) return;

            dic_float_property.Add(p.GetType(), p);
        }

        public float Get_Property(EProperty k)
        {
            if (!Is_Property(k)) return 0f;

            return dic_float_property[k].Value;
        }

        public void Plus_Property(FloatProperty p, EOperator o)
        {
            if (!Is_Property(p.GetType())) return;

            if (o == EOperator.Plus) dic_float_property[p.GetType()].Value += p.Value;
            if (o == EOperator.Minus) dic_float_property[p.GetType()].Value -= p.Value;
            if (o == EOperator.Mutiply) dic_float_property[p.GetType()].Value *= p.Value;
            if (o == EOperator.Divide) dic_float_property[p.GetType()].Value /= p.Value;
        }

        public void Plus_PropertyList(FloatProperty[] pl, EOperator o)
        {
            foreach (FloatProperty i in pl)
            {
                if (!Is_Property(i.GetType())) continue;

                if (o == EOperator.Plus) dic_float_property[i.GetType()].Value += i.Value;
                if (o == EOperator.Minus) dic_float_property[i.GetType()].Value -= i.Value;
                if (o == EOperator.Mutiply) dic_float_property[i.GetType()].Value *= i.Value;
                if (o == EOperator.Divide) dic_float_property[i.GetType()].Value /= i.Value;
            }

        }

        public bool Is_Property(EProperty k)
        {
            if (dic_float_property.ContainsKey(k)) return true;
            return false;
        }
    }
}