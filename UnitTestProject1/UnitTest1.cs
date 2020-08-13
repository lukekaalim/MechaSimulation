using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulation;
using System;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMechaCreation()
		{
			var initialGame = Game.Create();
			var addMecha = new Actions.AddedMecha(Mecha.ID.NewMechaID(Guid.NewGuid()), Game.Time.NewTime(0), new Vector2D(0, 0));
			var updatedGame = Game.Update(initialGame, Actions.Action.NewAddMecha(addMecha));

			Assert.AreEqual(updatedGame.mechas.Count, 1);
		}
	}
}
