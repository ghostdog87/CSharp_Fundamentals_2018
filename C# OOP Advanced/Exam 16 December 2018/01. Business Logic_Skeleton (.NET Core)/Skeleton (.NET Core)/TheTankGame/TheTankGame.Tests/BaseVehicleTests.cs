namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Core;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void CheckIfReturnCorrectResult()
        {
            var assembler = new VehicleAssembler();
           
            var tank = new Vanguard("SA - 203",100,300,1000,450,2000, assembler);
            var tank2 = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, assembler);
            var part1 = new ArsenalPart("Cannon - KA2", 300, 500, 450);
            var part2 = new ShellPart("Shields - PI1", 200, 1000, 750);


            var expectedResult = tank.ToString();
            var actualResult = "Vanguard - SA - 203\r\nTotal Weight: 100.000\r\nTotal Price: 300.000\r\nAttack: 1000\r\nDefense: 450\r\nHitPoints: 2000\r\nParts: None";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfReturnCorrectResult2()
        {
            var assembler = new VehicleAssembler();

            var tank = new Vanguard("SA - 203", 100, 300, 1000, 450, 2000, assembler);
            var tank2 = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, assembler);
            var part1 = new ArsenalPart("Cannon - KA2", 300, 500, 450);
            var part2 = new ShellPart("Shields - PI1", 200, 1000, 750);
            tank.AddArsenalPart(part1);
            tank.AddShellPart(part2);

            var expectedResult = tank.ToString();
            var actualResult = "Vanguard - SA - 203\r\nTotal Weight: 600.000\r\nTotal Price: 1800.000\r\nAttack: 1450\r\nDefense: 1200\r\nHitPoints: 2000\r\nParts: Cannon - KA2, Shields - PI1";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfReturnCorrectResultAfterBattle()
        {
            var assembler = new VehicleAssembler();

            var tank = new Vanguard("SA - 203", 100, 300, 1000, 450, 2000, assembler);
            var tank2 = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, assembler);
            var part1 = new ArsenalPart("Cannon - KA2", 300, 500, 450);
            var part2 = new ShellPart("Shields - PI1", 200, 1000, 750);
            var part3 = new EndurancePart("Shields - PI1", 200, 1000, 750);

            tank.AddArsenalPart(part1);
            tank2.AddShellPart(part2);
            tank2.AddEndurancePart(part3);


            var expectedResult = tank2.ToString();
            var actualResult = "Revenger - AKU\r\nTotal Weight: 1700.000\r\nTotal Price: 3500.000\r\nAttack: 1450\r\nDefense: 1750\r\nHitPoints: 1750\r\nParts: Shields - PI1, Shields - PI1";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}