using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace F1_EF_DF
{
    internal class Program
    {
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t<<< MENU >>>");
            Console.WriteLine("\t 0-Sair do Menu");
            Console.WriteLine("\t 1-Menu Piloto");
            Console.WriteLine("\t 2-Menu Carro");
            Console.WriteLine("\t 3-Menu Equipe");
            Console.Write("\t Escolha uma opção: ");
            int opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 0:
                    Console.Write("Saindo . ");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Environment.Exit(0);
                    break;
                case 1:
                    PilotMenu();
                    break;
                case 2:
                    CarMenu();
                    break;
                case 3:
                    TeamMenu();
                    break;
            }
        }

        static void PilotMenu()
        {
            Console.WriteLine("\t<<< PILOT MENU >>>");
            Console.WriteLine("\t 0-Retornar ao menu principal");
            Console.WriteLine("\t 1-Cadastrar Piloto");
            Console.WriteLine("\t 2-Editar Piloto");
            Console.WriteLine("\t 3-Deletar Piloto");
            Console.WriteLine("\t 4-Exibir todos Pilotos");
            Console.Write("\t Escolha uma opção: ");
            int opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    //Insert
                    Pilot p = new Pilot();
                    CarPilot cp = new CarPilot();
                    using (var context = new F1Entities())
                    {
                        Console.Write("Nome: ");
                        p.NamePilot = Console.ReadLine().ToUpper();
                        var find = context.Pilots.FirstOrDefault(c => c.NamePilot == p.NamePilot);
                        if (find != null)
                        {
                            Console.WriteLine("Piloto já cadastrado!");
                            return;
                        }
                        context.Pilots.Add(p);
                        //  cp.IdPilot = p.IdPilot;
                        // context.CarPilots.Add(cp);
                        context.SaveChanges();
                        Console.WriteLine("Piloto inserido com sucesso!");
                        Console.ReadKey();
                        break;
                    }

                case 2:

                    break;
                case 3:
                    break;
                case 4:
                    break;

            }
        }
        static void CarMenu()
        {
            Console.WriteLine("\t<<< CARRO MENU >>>");
            Console.WriteLine("\t 0-Retornar ao menu principal");
            Console.WriteLine("\t 1-Cadastrar Carro");
            Console.WriteLine("\t 2-Deletar Carro");
            Console.WriteLine("\t 3-Exibir todos Carros");
            Console.Write("\t Escolha uma opção: ");
            int opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 0:
                    Menu();
                    break;
                case 1://Insert
                    Car car = new Car();
                    using (var contextI = new F1Entities())
                    {
                        Console.Write("Ano: ");
                        car.Year = int.Parse(Console.ReadLine());
                        Console.Write("Modelo: ");
                        car.Model = Console.ReadLine();
                        Console.Write("Unidade: ");
                        car.Unit = int.Parse(Console.ReadLine());
                        var find = contextI.Cars.FirstOrDefault(c => c.Year == car.Year);
                        if (find != null)
                        {
                            var fin = contextI.Cars.FirstOrDefault(n => n.Model == car.Model);
                            if (fin != null)
                            {
                                var fi = contextI.Cars.FirstOrDefault(m => m.Unit == car.Unit);
                                if (fi != null)
                                {
                                    Console.WriteLine("Carro já cadastrado!");
                                    Console.ReadKey();
                                    return;
                                }
                            }

                        }
                        Console.Write("Id Equipe: ");
                        car.IdTeam = int.Parse(Console.ReadLine());
                        var f = contextI.Teams.FirstOrDefault(c => c.IdTeam == car.IdTeam);
                        if (f != null)
                        {
                            contextI.Cars.Add(car);
                            //car.IdCar = p.IdPilot;//devido ao relacionamento
                            //context.Cars.Add(car);
                            contextI.SaveChanges();
                            Console.WriteLine("Carro inserido com sucesso!");
                            Console.ReadKey();
                            break;

                        }
                        Console.WriteLine("Equipe não cadastrada!");
                        Console.WriteLine("Cadastro carro cancelado!");
                        Console.ReadKey();

                    }
                    break;
                case 2://Delet
                    Car ca = new Car();
                    using (var contextD = new F1Entities())
                    {
                        Console.Write("Ano: ");
                        ca.Year = int.Parse(Console.ReadLine());
                        Console.Write("Modelo: ");
                        ca.Model = Console.ReadLine();
                        Console.Write("Unidade: ");
                        ca.Unit = int.Parse(Console.ReadLine());
                        var find = contextD.Cars.FirstOrDefault(c => c.Year == ca.Year);
                        if (find != null)
                        {
                            var fin = contextD.Cars.FirstOrDefault(n => n.Model == ca.Model);
                            if (fin != null)
                            {
                                var fi = contextD.Cars.FirstOrDefault(m => m.Unit == ca.Unit);
                                if (fi != null)
                                {
                                    Console.WriteLine("Carro encontrado!");
                                    Console.WriteLine(ca.ToString());
                                    Console.WriteLine("Continuar deleção: 1-Sim 2-Não ");
                                    int op = int.Parse(Console.ReadLine());
                                    if (op == 2)
                                    {
                                        Console.WriteLine("Deleção Cancelada!");
                                        return;
                                    }
                                    contextD.Entry(fi).State = EntityState.Deleted;
                                    contextD.Cars.Remove(fi);
                                    contextD.SaveChanges();
                                    Console.ReadKey();
                                    return;
                                }
                            }

                        }
                    }
                    break;
                case 3://Select
                    var contextS = new F1Entities();
                    var cars = contextS.Cars.ToList();
                    foreach (var item in cars)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.ReadKey();
                    break;


            }
        }

        static void TeamMenu()
        {
            Console.WriteLine("\t<<< EQUIPE MENU >>>");
            Console.WriteLine("\t 0-Retornar ao menu principal");
            Console.WriteLine("\t 1-Cadastrar Equipe");
            Console.WriteLine("\t 2-Editar Equipe");
            Console.WriteLine("\t 3-Deletar Equipe");
            Console.WriteLine("\t 4-Exibir todas Equipes");
            Console.Write("\t Escolha uma opção: ");
            int opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 0:
                    Menu();
                    break;
                case 1://Insert
                    Team t = new Team();
                    using (var context = new F1Entities())
                    {
                        Console.Write("Nome: ");
                        t.NameTeam = Console.ReadLine().ToUpper();
                        var find = context.Teams.FirstOrDefault(c => c.NameTeam == t.NameTeam);
                        if (find != null)
                        {
                            Console.WriteLine("Equipe já cadastrada!");
                            return;
                        }
                        context.Teams.Add(t);
                        //  cp.IdPilot = p.IdPilot;
                        // context.CarPilots.Add(cp);
                        context.SaveChanges();
                        Console.WriteLine("Equipe inserida com sucesso!");
                        Console.ReadKey();
                        break;
                    }

            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
