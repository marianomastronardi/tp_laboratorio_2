using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionManager;
using Archivos;

namespace Entidades
{
  public class Universidad
  {
    public enum EClases
    {
      Programacion,
      Laboratorio,
      Legislacion,
      SPD
    }

    private List<Alumno> alumnos;
    private List<Jornada> jornada;
    private List<Profesor> profesaores;

    public List<Alumno> Alumnos { get {return this.alumnos;} set; }
    public List<Profesor> Instructores { get { return this.profesaores; } set; }
    public List<Jornada> Jornadas { get { return this.jornada; } set; }

    public Jornada this[int i] { get { return this.jornada[i]; } set; }

    public Universidad()
    {

    }

    public override string ToString()
    {
      return base.ToString();
    }

    public bool Guardar(Universidad uni)
    {
      return new Xml<Universidad>().Guardar("Universidad", uni);
    }

    private static string MostrarDatos(Universidad uni)
    {
      return uni.ToString();
    }

    public static bool operator ==(Universidad g, Alumno a)
    {
      return g.Alumnos.Contains(a);
    }

    public static bool operator ==(Universidad g, Profesor i)
    {
      return g.Instructores.Contains(i);
    }

    public static Profesor operator ==(Universidad u, EClases clase)
    {
      Profesor p;

      foreach(Profesor a in u.Instructores)
      {
        if(a==clase)
        {
          p = new Profesor();
          p = a;
          break;
        }
      }
      if(p==null)
        throw new SinProfesorException();
      return p;
    }

    public static bool operator !=(Universidad g, Alumno a)
    {
      return (!(g == a));
    }

    public static bool operator !=(Universidad g, Profesor i)
    {
      return (!(g == i));
    }

    public static Profesor operator !=(Universidad u, EClases clase)
    {
      Profesor p;

      foreach (Profesor a in u.Instructores)
      {
        if (a!=clase)
        {
          p = new Profesor();
          p = a;
          break;
        }
      }
      if (p == null)
        throw new SinProfesorException();
      return p;
    }

    public static Universidad operator +(Universidad g, EClases clase)
    {
      
    }

    public static Universidad operator +(Universidad u, Alumno a)
    {

    }

    public static Universidad operator +(Universidad u, Profesor i)
    {

    }
  }
}
