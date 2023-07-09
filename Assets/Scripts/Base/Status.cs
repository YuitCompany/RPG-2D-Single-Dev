using System.Collections.Generic;
using Property;

namespace Status
{
    public class FloatProperty : IProperty<float, EProperty>
    {
        EProperty key;
        float value;

        public FloatProperty(EProperty key, float value)
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

        public float Get_Property(EProperty k)
        {
            if (!Is_Property(k)) return 0f;

            return dic_float_property[k].Value;
        }
    
        public void Set_Property(FloatProperty p)
        {
            if (Is_Property(p.GetType())) return;

            dic_float_property.Add(p.GetType(), p);
        }
        public void Set_Property(EProperty k, float v)
        {
            if (Is_Property(k)) return;

            dic_float_property.Add(k, new FloatProperty(k, v));
        }
        public void Set_PropertyList(List<EProperty> lk, List<float> lv, int i = 0)
        {
            if (i >= lk.Count) return;
            if (Is_Property(lk[i])) Set_PropertyList(lk, lv, i + 1);

            Set_Property(lk[i], lv[i]);

            Set_PropertyList(lk, lv, i + 1);
        }

        public void Change_Property(FloatProperty p, EOperator o)
        {
            if (!Is_Property(p.GetType())) return;

            if (o == EOperator.Plus) dic_float_property[p.GetType()].Value += p.Value;
            if (o == EOperator.Minus) dic_float_property[p.GetType()].Value -= p.Value;
            if (o == EOperator.Mutiply) dic_float_property[p.GetType()].Value *= p.Value;
            if (o == EOperator.Divide) dic_float_property[p.GetType()].Value /= p.Value;
        }
        public void Change_Property(Status s, EOperator o)
        {
            foreach(FloatProperty i in s.dic_float_property.Values)
            {
                Change_Property(i, o);
            }
        }

        public void Change_PropertyList(List<FloatProperty> lp, EOperator o)
        {
            foreach (FloatProperty i in lp)
            {
                if (!Is_Property(i.GetType())) continue;

                if (o == EOperator.Plus) dic_float_property[i.GetType()].Value += i.Value;
                if (o == EOperator.Minus) dic_float_property[i.GetType()].Value -= i.Value;
                if (o == EOperator.Mutiply) dic_float_property[i.GetType()].Value *= i.Value;
                if (o == EOperator.Divide) dic_float_property[i.GetType()].Value /= i.Value;
            }
        }
        public void Change_PropertyList(List<EProperty> lk, List<float> lv, EOperator o, int i = 0)
        {
            if (i >= lk.Count) return;
            if (!Is_Property(lk[i])) Change_PropertyList(lk, lv, o, i + 1);

            if (o == EOperator.Plus) dic_float_property[lk[i]].Value += lv[i];
            if (o == EOperator.Minus) dic_float_property[lk[i]].Value -= lv[i];
            if (o == EOperator.Mutiply) dic_float_property[lk[i]].Value *= lv[i];
            if (o == EOperator.Divide) dic_float_property[lk[i]].Value /= lv[i];

            Change_PropertyList(lk, lv, o, i + 1);
        }

        public bool Is_Property(EProperty k)
        {
            if (dic_float_property.ContainsKey(k)) return true;
            return false;
        }
        public bool Is_Equal(Status s)
        {
            if (dic_float_property.Count != s.dic_float_property.Count) return false;

            foreach(FloatProperty i in s.dic_float_property.Values)
            {
                if (!Is_Property(i.GetType())) return false;
                if (i.Value != dic_float_property[i.GetType()].Value) return false;
            }
            
            return true;
        }
    }
}