using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMechaCreation()
		{
			var alphaMecha = Mecha.Create(new Vector2D.T(0, 0));

			var world = World.Dispatch(World.Create(), Actions.SpawnMecha(0, alphaMecha));

			Assert.AreEqual(world.mechas[alphaMecha.id].position.x, 0);
			Assert.AreEqual(world.mechas[alphaMecha.id].position.y, 0);

			var movingMechaWorld = World.Dispatch(world, Actions.DriveMecha(0, alphaMecha.id, new Vector2D.T(1, 0)));

			var worldAfterMoving = World.Simulate(movingMechaWorld, 10);

			Assert.AreEqual(worldAfterMoving.mechas[alphaMecha.id].position.x, 10);
		}
		
		[TestMethod]
		public void TestPhysics() {
			var particleA = new Physics.Particle1D(0, 1, 0);
			var particleB = new Physics.Particle1D(10, -1, 0);

			var collision = Physics.GetCollision1D(particleA, particleB);

			Assert.IsTrue(collision.IsHit);
			Assert.IsFalse(collision.IsMiss);
			Assert.AreEqual((collision as Physics.Collision1DResult.Hit).entry, 5);
			Assert.AreEqual((collision as Physics.Collision1DResult.Hit).exit, 5);
		}
	}
}
