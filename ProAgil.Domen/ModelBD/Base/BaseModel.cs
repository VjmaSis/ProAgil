using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Domen.ModelBD.Base
{
    public class BaseModel
    {
        public int ID { get; set; }
        public object GetClone()
        {
            return MemberwiseClone();
        }
    }
}
