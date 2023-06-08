namespace CraftDemo.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserName_SetValidUsername_UsernameIsSet()
        {
            // Arrange
            var user = new GitHubUser();
            
            // Act
            user.UserName = "testuser";

            // Assert
            Assert.AreEqual("testuser", user.UserName);
        }

        [Test]
        public void UserName_SetEmptyUsername_ThrowsArgumentNullException()
        {
            // Arrange
            var user = new GitHubUser();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => user.UserName = "");
        }

        [Test]
        public void NodeId_SetValidNodeId_NodeIdIsSet()
        {
            // Arrange
            var user = new GitHubUser();

            // Act
            user.NodeId = "123456";

            // Assert
            Assert.AreEqual("123456", user.NodeId);
        }

        [Test]
        public void NodeId_SetNullNodeId_ThrowsArgumentNullException()
        {
            // Arrange
            var user = new GitHubUser();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => user.NodeId = null);
        }

        // Add more unit tests for the other properties and their respective validation rules...

        [Test]
        public void LastUpdatedAt_SetValidDate_LastUpdatedAtIsSet()
        {
            // Arrange
            var user = new GitHubUser();
            var createdAt = new DateTime(2022, 1, 1);
            user.CreatedAt = createdAt;

            // Act
            user.LastUpdatedAt = new DateTime(2023, 1, 1);

            // Assert
            Assert.AreEqual(new DateTime(2023, 1, 1), user.LastUpdatedAt);
        }

        [Test]
        public void LastUpdatedAt_SetEarlierDateThanCreatedAt_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var user = new GitHubUser();
            var createdAt = new DateTime(2022, 1, 1);
            user.CreatedAt = createdAt;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => user.LastUpdatedAt = new DateTime(2021, 1, 1));
        }
    }
}