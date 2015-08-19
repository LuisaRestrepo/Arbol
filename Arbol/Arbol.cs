using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Arbol
{
    public class Arbol
    {

        public Nodo Rescate;

        [DebuggerDisplayAttribute("Valor = {inf}")]
        public class Nodo 
        {
            public int inf;
            public Nodo izq;
            public Nodo der;
            public Nodo pad;
        }

        public Nodo Raiz;

        public Arbol(int R)
        {
            Raiz = new Nodo { inf = R };
        }

        public Arbol() { }

        public void Limpiar()
        {
            Raiz = null;
        }

        public void Insertar(int Z)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo() { inf = Z };
                return;
            }
            Nodo N = Raiz;
            while (true)
            {
                if (N.inf >= Z && N.izq != null)
                {
                    N = N.izq;
                    continue;
                }
                if (N.inf < Z && N.der != null)
                {
                    N = N.der;
                    continue;
                }
                break;
            }
            if (N.inf < Z)
            {
                N.der = new Nodo() { inf = Z, pad = N };
                Balancear(N.der);
                return;
            }
            if (N.inf >= Z)
            {
                N.izq = new Nodo() { inf = Z, pad = N };
                Balancear(N.izq);
                return;
            }
        }

        public void AgregarNodo(Nodo A)
        {
            if (A == null) return;
            Nodo N = Raiz;
            while (true)
            {
                if (N.inf >= A.inf && N.izq != null)
                {
                    N = N.izq;
                    continue;
                }
                if (N.inf < A.inf && N.der != null)
                {
                    N = N.der;
                    continue;
                }
                break;
            }
            if (N.inf < A.inf)
            {
                N.der = A;
                A.pad = N;
                Balancear(A);
                return;
            }
            if (N.inf >= A.inf)
            {
                N.izq = A;
                A.pad = N;
                Balancear(A);
                return;
            }
        }

        public void Balancear(Nodo Fuente)
        {
            while (true)
            {
                if (NecesitaBalanceo(Fuente))
                {
                    //Balancear!!
                    if (Fuente.pad != null)
                    {
                        Nodo Pad = Fuente.pad;
                        Nodo Bal = BalanceoSimple(Fuente);
                        Bal.pad = Pad;
                        if (Pad.inf < Bal.inf) { Pad.der = Bal; }
                        else { Pad.izq = Bal; }
                    }
                    else
                    {
                        Raiz = BalanceoSimple(Fuente);
                        Raiz.pad = null;
                    }
                    if (Rescate != null)
                    {
                        Rescate.pad = null;
                        AgregarNodo(Rescate);
                        Rescate = null;
                    }
                }
                Fuente = Fuente.pad;
                if (Fuente == null) break;
            }
        }

        public Nodo BalanceoSimple(Nodo Fuente)
        {
            if (CalcularAltura(Fuente.izq) < CalcularAltura(Fuente.der) + 1)
            {
                //Izquierda
                Nodo Copia = Fuente.der;
                Rescate = Copia.izq;
                //Copia.pad = Fuente.pad;
                Fuente.pad = Copia;       
                Copia.izq = Fuente;
                Fuente.der = null;
                return Copia;
            }
            else
            {
                //Derecha
                Nodo Copia = Fuente.izq;
                Rescate = Copia.der;
                //Copia.pad = Fuente.pad;
                Fuente.pad = Copia;
                Copia.der = Fuente;
                Fuente.izq = null;
                return Copia;
            }
        }

        public Boolean Eliminar(int Z)
        {
            if (Raiz == null) return false;
            if (Z == Raiz.inf)
            {
                //Nodo BackUp = null;
                //Nodo Switch;
                //if (Raiz.der == null && Raiz.izq == null) { Raiz = null; return; }
                //if (Raiz.izq == null)
                //{
                //    Switch = Raiz.der;
                //    Raiz = Switch;
                //    Raiz.pad = null;
                //    Balancear(Raiz);
                //    return;
                //}
                //if (Raiz.der == null)
                //{
                //    Switch = Raiz.izq;
                //    Raiz = Switch;
                //    Raiz.pad = null;
                //    Balancear(Raiz);
                //    return;
                //}
                //Switch = Raiz.izq;
                //if (Switch.der == null) Switch.der = Raiz.der;
                //else
                //{
                //    BackUp = Switch.der;
                //    Switch.der = Raiz.der;
                //}
                //Switch.izq = Raiz.izq.izq;
                //Raiz.der.pad = Switch;
                //Switch.pad = null;
                //Raiz = Switch;
                //AgregarNodo(BackUp);
                //Balancear(Raiz);
                //return;
                return false;
            }
            Nodo N = Raiz;
            while (N != null)
            {
                if (N.inf == Z)
                {
                    Nodo pad = N.pad;
                    Nodo izq = N.izq;
                    Nodo der = N.der;
                    if (pad.izq != null && pad.izq.inf == Z)
                    {
                        pad.izq = null;
                    }
                    if (pad.der != null && pad.der.inf == Z)
                    {
                        pad.der = null;
                    }
                    AgregarNodo(izq);
                    AgregarNodo(der);
                    return true;
                }
                if (N.inf > Z)
                {
                    N = N.izq;
                    continue;
                }
                N = N.der;
            }
            return false;
        }

        public int CalcularAltura(Nodo Fuente)
        {
            if (Fuente != null) return Math.Max(CalcularAltura(Fuente.izq), CalcularAltura(Fuente.der)) + 1;
            else { return 0; }
        }

        public Boolean NecesitaBalanceo(Nodo Fuente)
        {
            int dif = CalcularAltura(Fuente.izq) - CalcularAltura(Fuente.der);
            return dif > 1 || dif < -1;
        }

        public String EnOrden(Nodo Inicio)
        {
            if (Inicio == null) return "";
            String Retorno = "";
            Retorno += EnOrden(Inicio.izq);
            Retorno += Inicio.inf.ToString();
            Retorno += EnOrden(Inicio.der);
            return Retorno;
        }

        public String PosOrden(Nodo Inicio)
        {
            if (Inicio == null) return "";
            String Retorno = "";
            Retorno += PosOrden(Inicio.izq);
            Retorno += PosOrden(Inicio.der);
            Retorno += Inicio.inf.ToString();
            return Retorno;
        }

        public String PreOrden(Nodo Inicio)
        {
            if (Inicio == null) return "";
            String Retorno = "";
            Retorno += Inicio.inf.ToString();
            Retorno += PreOrden(Inicio.izq);
            Retorno += PreOrden(Inicio.der);
            return Retorno;
        }
    }

}
