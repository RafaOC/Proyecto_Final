using System;

namespace Proyecto_Final
{
    class asistencia
    {
        public double monto;
        public double plazo;
        public double tasa;
    }
    class Program
    {
      static void presentar()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------CALCULADORA DE PRÉSTAMOS------------");
            Console.WriteLine("------------------------------------------------\n");

            Console.WriteLine("Presiona una tecla para iniciar...");
            Console.ReadKey();
            Console.Clear();
        }
        static void CuadroAmortizacion( double tasa, double cuotas,  double resta,  double plazo)
        {
            double[] balance = new double[60];
            double[] capital = new double[60];
            double[] interes = new double[60];
            tasa = tasa / 100;
           
           Console.WriteLine("|************************************************************|");
           Console.WriteLine("{0,3}{1,10:N2}{2,16:N2}{3,14:N2}{4,14:N2}", " Pago", "Cuota", "Capital", "Interés", "Balance ");
           
            for (int k = 0; k < plazo; k++)
            {
                interes[k] = resta * tasa / 12;
                resta += interes[k] - cuotas;
                capital[k] = cuotas - interes[k];
                balance[k] = resta;
                 
                Console.WriteLine("{0,3}{1,14:N2}{2,14:N2}{3,14:N2}{4,14:N2}", k + 1, cuotas, capital[k], interes[k], balance[k]);
            }
           Console.WriteLine("|************************************************************|");
        }
           
        static double Calcular(double monto, double plazo, double tasa)
        {
            //Cuota
            double k, cuota;
            tasa = (tasa / 1200);
            k = Math.Pow((1 + tasa), plazo);
            cuota = tasa * monto * k / (k - 1);
            return cuota;  
        }
        
        static void Main(string[] args)
        {
            double m, t, p; //m = monto, t= tasa, p= plazo.
            double cuotasFinal; //Almacenar la funcion Calcular

            asistencia ast = new asistencia();
            presentar();

            Console.Write("Introduzca el Monto del prestamo en RD$: ");
            ast.monto = double.Parse(Console.ReadLine()); 
            m = ast.monto;
            Console.Clear();

            Console.Write("Introduzca la Tasa de Porcentaje Anual: ");
            ast.tasa = double.Parse(Console.ReadLine());
            t = ast.tasa;
            Console.Clear();

            Console.Write("Introduzca el plazo: ");
            ast.plazo = double.Parse(Console.ReadLine());
            p = ast.plazo;
            Console.Clear();

            cuotasFinal = Calcular(m, p, t);

            Console.WriteLine("Valor cuota: RD${0}\n", cuotasFinal );

            CuadroAmortizacion( t, cuotasFinal,  m,  p);

            Console.WriteLine("\nPresiona una tecla para finalizar...");
            Console.ReadKey();
        }
    } 
}