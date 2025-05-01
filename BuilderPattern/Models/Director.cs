using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder {
  class Director {
    public void Build(IDatabaseBuilder Builder) {
      //By using the director we can reduce the code needed
      //To do one of these steps, other wise we risk a change
      //of code repeating. This way we just use "Build" and then its done.
      Builder.BuildConnection();
      Builder.BuildCommand();
      Builder.SetSettings();
    }
  }
}