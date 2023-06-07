using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAttributes.Reflection.Types {
    public class Patient {
        int id;
        double age;
        bool dead;

        public void TestType() {
            var t = this.GetType();
            var tId = this.id.GetType();
            var tAge = this.id.GetType();
            var tDead = this.id.GetType();

            var t1 = typeof(Patient);
            var eq = t == t1;
        }

    }
}
