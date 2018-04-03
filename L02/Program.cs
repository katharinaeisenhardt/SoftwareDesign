using System;

namespace L02
{
    class Program
    {
        public static double v;
        public static double a;

        static void Main(string[] args)/*args=Parameter */
        {
            Console.WriteLine("Koerper: w=Kubus k=Kugel o=Oktaeder");
            Console.WriteLine("Bitte Körper (w,k,oder o) und eine Größe (Kantenlänge bzw. Durchmesser) angeben.");
            var korper = args[0];
            var d = double.Parse(args[1]);

            switch (korper)
            {
                case "w":
                case "Kubus":
                    getCubeInfo(d);
                    break;
                case "k":
                case "Kugel":
                    getSphereInfo(d);
                    break;
                case "o":
                case "Oktaeder":
                    getOktaederInfo(d);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                    break;
            }
        }

        public static void getCubeSurface(double d){ /*static nicht vergessen! */
            a = 6*(d*d);
            /*return a^^ */
        }

        public static void getCubeVolume(double d){
            v = Math.Pow(d, 3);
            /*return v^^ */
        }

        public static void getSphereSurface(double d){
            a = System.Math.PI*Math.Pow(d, 2);
            /*return a^^ */
        }

        public static void getSphereVolume(double d){ 
            v = System.Math.PI*Math.Pow(d, 3)/6;
            /*return v^^ */
        }

        public static void getOktaederSurface(double d){
            a = 2*(Math.Sqrt(3))*Math.Pow(d, 2);
            /*return a^^ */
        }

        public static void getOktaederVolume(double d){
            v = (Math.Sqrt(2))*Math.Pow(d, 3)/3;
            /*return v^^ */
        }

        public static void getCubeInfo(double d){
            getCubeSurface(d);
            getCubeVolume(d);
            Console.WriteLine("Kubus: A = " + Math.Round(a, 2) + " | V = " + Math.Round(v, 2));
        }

        public static void getSphereInfo(double d){
            getSphereSurface(d);
            getSphereVolume(d);
            Console.WriteLine("Kugel: A = " + Math.Round(a, 2) + " | V = " + Math.Round(v, 2));
        }

        public static void getOktaederInfo(double d){
            getOktaederSurface(d);
            getOktaederVolume(d);
            Console.WriteLine("Oktaeder: A = " + Math.Round(a, 2) + " | V = " + Math.Round(v, 2));
        }
    }
}
