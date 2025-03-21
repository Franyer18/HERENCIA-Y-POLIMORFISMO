using System;

namespace MisClases
{
    internal class Vehiculo
    {
        public string Color { get; set; }
        public string Modelo { get; }
        public int Year { get; }

        private int velocidad = 0; 

        public Vehiculo(int anio, string elColor, string elModelo)
        {
            this.Color = elColor;
            this.Modelo = elModelo;
            this.Year = anio;
        }

        public void InformacionVehiculo()
        {
            Console.WriteLine("Color: {0}", this.Color);
            Console.WriteLine("Modelo: {0}", this.Modelo);
            Console.WriteLine("Año: {0}", this.Year);
        }

        public virtual void Acelerar(int cuanto)
        {
            velocidad += cuanto;
            Console.WriteLine("{0} {1} va a {2} KMS/Hora", Modelo, Year, velocidad);
        }

        public virtual void Frenar()
        {
            if (velocidad > 0)
            {
                velocidad -= 10;
                Console.WriteLine("{0} {1} está frenando. Velocidad actual: {2} KMS/Hora", Modelo, Year, velocidad);
            }
            else
            {
                Console.WriteLine("{0} {1} ya está detenido.", Modelo, Year);
            }
        }

        public virtual void Encender()
        {
            Console.WriteLine("{0} {1} está encendiendo...", Modelo, Year);
        }

        public virtual void Apagar()
        {
            Console.WriteLine("{0} {1} está apagando...", Modelo, Year);
        }
    }

   
    internal class AutoDeCombustion : Vehiculo
    {
        private int nivelCombustible;

        public int Cilindraje { get; set; }
        public string TipoCombustible { get; set; }

        public AutoDeCombustion(int anio, string elColor, string elModelo, int cilindraje, string tipoCombustible)
            : base(anio, elColor, elModelo)
        {
            Cilindraje = cilindraje;
            TipoCombustible = tipoCombustible;
            nivelCombustible = 100;
        }

        public override void Acelerar(int cuanto)
        {
            base.Acelerar(cuanto);
            nivelCombustible -= 5;
            Console.WriteLine("Nivel de combustible: {0}%", nivelCombustible);
        }

        public override void Frenar()
        {
            base.Frenar();
            Console.WriteLine("El auto de combustión gasta un poco de gasolina al frenar.");
        }

        public override void Encender()
        {
            Console.WriteLine("Auto de combustión encendiendo... Nivel de combustible: {0}%", nivelCombustible);
        }
    }
    internal class Motocicleta : Vehiculo
    {
        private bool casco;

        public string TipoMoto { get; set; }
        public int Cilindraje { get; set; }

        public Motocicleta(int anio, string elColor, string elModelo, string tipoMoto, int cilindraje)
            : base(anio, elColor, elModelo)
        {
            TipoMoto = tipoMoto;
            Cilindraje = cilindraje;
            casco = false;
        }

        public override void Acelerar(int cuanto)
        {
            base.Acelerar(cuanto + 10); 
            Console.WriteLine("¡La motocicleta aceleró rápidamente!");
        }

        public override void Frenar()
        {
            base.Frenar();
            Console.WriteLine("La motocicleta se detuvo más rápido.");
        }

        public override void Encender()
        {
            Console.WriteLine("Motocicleta rugiendo al encender.");
        }
    }

   
    internal class Camion : Vehiculo
    {
        private int cargaActual; 

        public int CapacidadCarga { get; set; }
        public int NumeroEjes { get; set; }

        public Camion(int anio, string elColor, string elModelo, int capacidadCarga, int numeroEjes)
            : base(anio, elColor, elModelo)
        {
            CapacidadCarga = capacidadCarga;
            NumeroEjes = numeroEjes;
            cargaActual = 0;
        }

        public override void Acelerar(int cuanto)
        {
            base.Acelerar(cuanto / 2); 
            Console.WriteLine("El camión necesita más tiempo para acelerar.");
        }

        public override void Frenar()
        {
            base.Frenar();
            Console.WriteLine("El camión usa frenos de aire para detenerse.");
        }

        public override void Encender()
        {
            Console.WriteLine("El camión con motor diésel está encendido.");
        }
    }

    
    class Program
    {
        static void Main()
        {
            AutoDeCombustion auto = new AutoDeCombustion(2022, "Rojo", "Nisa Fronter", 1600, "Gasolina");
            auto.Encender();
            auto.Acelerar(20);
            auto.Frenar();

            Console.WriteLine("\n");

            Motocicleta moto = new Motocicleta(2023, "Negro", "Pulsar Ns 2000", "doble proposito", 600);
            moto.Encender();
            moto.Acelerar(30);
            moto.Frenar();

            Console.WriteLine("\n");

            Camion camion = new Camion(2021, "Azul", "toyota 4x4", 20000, 4);
            camion.Encender();
            camion.Acelerar(15);
            camion.Frenar();
        }
    }
}
