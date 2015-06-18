namespace StarCrash.Ship {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  public interface IHasParent<P> {

    P Parent { get;}

    void SetParent(P parent);
  }
}
