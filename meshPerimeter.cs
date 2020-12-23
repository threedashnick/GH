using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;



/// <summary>
/// This class will be instantiated on demand by the Script component.
/// </summary>
public class Script_Instance : GH_ScriptInstance
{
#region Utility functions
  /// <summary>Print a String to the [Out] Parameter of the Script component.</summary>
  /// <param name="text">String to print.</param>
  private void Print(string text) { /* Implementation hidden. */ }
  /// <summary>Print a formatted String to the [Out] Parameter of the Script component.</summary>
  /// <param name="format">String format.</param>
  /// <param name="args">Formatting parameters.</param>
  private void Print(string format, params object[] args) { /* Implementation hidden. */ }
  /// <summary>Print useful information about an object instance to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj) { /* Implementation hidden. */ }
  /// <summary>Print the signatures of all the overloads of a specific method to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj, string method_name) { /* Implementation hidden. */ }
#endregion

#region Members
  /// <summary>Gets the current Rhino document.</summary>
  private readonly RhinoDoc RhinoDocument;
  /// <summary>Gets the Grasshopper document that owns this script.</summary>
  private readonly GH_Document GrasshopperDocument;
  /// <summary>Gets the Grasshopper script component that owns this script.</summary>
  private readonly IGH_Component Component;
  /// <summary>
  /// Gets the current iteration count. The first call to RunScript() is associated with Iteration==0.
  /// Any subsequent call within the same solution will increment the Iteration count.
  /// </summary>
  private readonly int Iteration;
#endregion

  /// <summary>
  /// This procedure contains the user code. Input parameters are provided as regular arguments,
  /// Output parameters as ref arguments. You don't have to assign output parameters,
  /// they will have a default value.
  /// </summary>
  private void RunScript(List<Curve> linii, ref object A)
  {
    // Kirill Rodin / alternative mech contour / эта штука работает долго и грузит скрипт. её лучше переписать
    List<Point3d> tochki = new List<Point3d>();
    List<Curve> itog = new List<Curve>();

    foreach (Curve linia in linii)
    {
      Point3d pt1 = linia.PointAtLength(linia.GetLength() * 0.5);
      //     Point3d pt1 = linia.PointAt(0.5);   почему это не работает так?
      tochki.Add(pt1);

      int i = 0;
      foreach (Curve linia2 in linii)
      {
        Point3d pt2 = linia2.PointAtLength(linia2.GetLength() * 0.5);
        if (pt1.X == pt2.X)
        {
          i++;
        }
      }
      Print(i.ToString());
      if (i == 1)
      {
        itog.Add(linia);
      }

      //      Print(i.ToString());
    }
    A = itog;
  }

  // <Custom additional code> 

  // </Custom additional code> 
}
