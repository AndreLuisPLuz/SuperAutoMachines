using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Machine.Types;
using SuperAutoMachines.Core.Battle.Generator;

BaseMachine[] myTeam = new BaseMachine[3];
myTeam[0] = new Belt();
myTeam[1] = new Hammer();
myTeam[2] = new Screwdriver();

var myBattle = new Battle(myTeam, GeneratorTier.ONE, GeneratorTier.ONE);

Console.WriteLine("Meu time:");
foreach (var fighter in myBattle.BlueTeam)
    Console.WriteLine(fighter.Name);

Console.WriteLine("\nTime inimigo:");
foreach (var fighter in myBattle.RedTeam)
    Console.WriteLine(fighter.Name);