using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDemo
{
    public class ServerObject : MarshalByRefObject
    {
        public Person GetPerson(string name, int age)
        {
            Person p = new Person()
            {
                Name = name,
                Age = age
            };
            return p;
        }
    }
}
